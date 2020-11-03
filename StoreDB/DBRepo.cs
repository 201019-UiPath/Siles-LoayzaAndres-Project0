using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreDB.Models;

namespace StoreDB
{
    public class DBRepo : IRepo
    {
        StoreContext context;
        Customer currentCustomer;
        Location currentLocation;

        public DBRepo(StoreContext context)
        {
            this.context = context;
        }

        public void AddLocation(Location location)
        {
            context.StoreLocations.Add(location);
            context.SaveChanges();
        }

        public void AddNewProduct(InvItem invItem)
        {
            Location loc = context.StoreLocations.Single(x => x.Id == currentLocation.Id);
            loc.Inventory = new List<InvItem>();
            loc.Inventory.Add(invItem);
            context.SaveChanges();
        }

        public void AddCartItem(CartItem cartItem)
        {
            context.CartItems.Add(cartItem);
            context.SaveChanges();
        }

        public void AddToProductQuantity(int index, int quantityAdded)
        {
            GetInventory()[index].Quantity += quantityAdded;
            context.SaveChanges();
        }

        private void CreateCartIfItDoesNotExist()
        {
            if (!context.Carts.Any(x => x.CustomerId == currentCustomer.Id && x.LocationId == currentLocation.Id))
            {
                Cart cart = new Cart();
                cart.LocationId = currentLocation.Id;
                cart.CustomerId = currentCustomer.Id;
                cart.Items = new List<CartItem>();
                context.Carts.Add(cart);
                context.SaveChanges();
            }
        }

        public void EmptyCart()
        {
            GetCart().Items.Clear();
            context.SaveChanges();
        }

        public Cart GetCart()
        {
            CreateCartIfItDoesNotExist();
            Cart cart = context.Carts.Single(x => x.CustomerId == currentCustomer.Id && x.LocationId == currentLocation.Id);
            cart.Items = context.CartItems.Include("Product").Where(x => x.CartId == cart.Id).ToList();
            return cart;
        }

        public Customer GetCustomer()
        {
            return currentCustomer;
        }

        public List<Order> GetCustomerOrders()
        {
            List<Order> orders = context.Orders.Where(x => x.CustomerId==currentCustomer.Id).ToList();
            foreach(Order o in orders)
            {
                o.Items = context.OrderItems.Include("Product").Where(x => x.OrderId == o.Id).ToList();
            }
            return orders;
        }

        public List<InvItem> GetInventory()
        {
            return context.InvItems.Include("Product").Where(x => x.LocationId==currentLocation.Id).ToList();
        }

        public Location GetLocation()
        {
            return currentLocation;
        }

        public Task<List<Location>> GetLocations()
        {
            return context.StoreLocations.Select(x => x).ToListAsync();
        }

        public List<Order> GetLocationOrders()
        {
            List<Order> orders = context.Orders.Where(x => x.LocationId==currentLocation.Id).ToList();
            foreach(Order o in orders)
            {
                o.Items = context.OrderItems.Include("Product").Where(x => x.OrderId == o.Id).ToList();
                o.CustomerAddress = context.Addresses.Single(x => x.Id == o.CustomerId);
            }
            return orders;
        }

        public void PlaceOrder(Order order)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                foreach(CartItem item in GetCart().Items)
                {
                    RemoveInventory(item.ProductId, item.Quantity);
                }
                context.SaveChanges();
                EmptyCart();
                context.SaveChanges();
                context.Orders.Add(order);
                context.SaveChanges();
                transaction.Commit();
            }
        }

        public void RemoveProductFromCart(int productId)
        {
            CartItem cartItem = context.CartItems.Single(x => x.ProductId == productId);
            context.CartItems.Remove(cartItem);
            context.SaveChanges();
        }

        public void RemoveInventory(int productId, int quantity)
        {
            context.InvItems.Single(x => x.LocationId==currentLocation.Id && x.Product.Id==productId).Quantity -= quantity;
            context.SaveChanges();
        }

        public ICustomerRepo SetCurrentCustomer(int id)
        {
            currentCustomer = context.Customers.Single(x => x.Id == id);
            return this;
        }

        public ILocationRepo SetCurrentLocation(Location location)
        {
            currentLocation = location;
            return this;
        }
    }
}