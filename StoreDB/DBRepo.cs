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
            context.StoreLocations.AddAsync(location);
            context.SaveChanges();
        }

        public void AddNewProduct(InvItem invItem)
        {
            Location loc = context.StoreLocations.Single(x => x.Id == currentLocation.Id);
            loc.Inventory = new List<InvItem>();
            loc.Inventory.Add(invItem);
            context.SaveChanges();
        }

        public void AddOrderToCustomer(Order order)
        {
            context.Customers.Include("Orders")
                             .Single(x => x.Id == currentCustomer.Id).Orders
                             .Add(order);
            context.SaveChanges();
        }

        public void AddOrderToLocation(Order order)
        {
            context.StoreLocations.Include("Orders")
                                  .Single(x => x.Id == currentLocation.Id).Orders
                                  .Add(order);
            context.SaveChanges();
        }

        public void AddCartItem(CartItem cartItem)
        {
            context.CartItems.AddAsync(cartItem);
            context.SaveChanges();
        }

        public void AddToProductQuantity(int index, int quantityAdded)
        {
            GetInventory().Result[index].Quantity += quantityAdded;
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
            GetCart().Result.Items.Clear();
            context.SaveChanges();
        }

        public Task<Cart> GetCart()
        {
            CreateCartIfItDoesNotExist();
            return context.Carts.Include("Products").SingleAsync(x => x.CustomerId == currentCustomer.Id && x.LocationId == currentLocation.Id);
        }

        public Customer GetCustomer()
        {
            return currentCustomer;
        }

        public List<Order> GetCustomerOrders()
        {
            return context.Customers.Include("Orders").Single(x => x.Id ==currentCustomer.Id).Orders;
        }

        public Task<List<InvItem>> GetInventory()
        {
            return context.InvItems.Include("Product").Where(x => x.LocationId == currentLocation.Id).ToListAsync();
        }

        public Location GetLocation()
        {
            return currentLocation;
        }

        public Task<List<Location>> GetLocations()
        {
            return context.StoreLocations.Select(x => x).ToListAsync();
        }

        public void PlaceOrder(Order order)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                foreach(CartItem item in GetCart().Result.Items)
                {
                    throw new System.NotImplementedException();
                }
                context.SaveChanges();
                EmptyCart();
                context.SaveChanges();
                AddOrderToLocation(order);
                context.SaveChanges();
                AddOrderToCustomer(order);
                context.SaveChanges();
                transaction.Commit();
            }
        }

        public void RemoveFromCart(int index)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveInventory(InvItem invItem)
        {
            context.InvItems.Single(x => x.LocationId==currentLocation.Id && x.Product.Id==invItem.Product.Id).Quantity -= invItem.Quantity;
            context.SaveChanges();
        }

        public IShopRepo SetCurrentCustomer(int id)
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