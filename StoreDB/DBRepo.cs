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
            context.InvItems.Add(invItem);
            context.SaveChanges();
        }

        public void AddCartItem(CartItem cartItem)
        {
            context.CartItems.Add(cartItem);
            context.SaveChanges();
        }

        public void AddToProductQuantity(int locationId, int productId, int quantityAdded)
        {
            context.InvItems.Single(x => x.LocationId==locationId && x.ProductId==productId).Quantity += quantityAdded;
            context.SaveChanges();
        }

        private void CreateCartIfItDoesNotExist(int customerId, int locationId)
        {
            if (!context.Carts.Any(x => x.CustomerId==customerId && x.LocationId==locationId))
            {
                Cart cart = new Cart();
                cart.LocationId = locationId;
                cart.CustomerId = customerId;
                cart.Items = new List<CartItem>();
                context.Carts.Add(cart);
                context.SaveChanges();
            }
        }

        public void EmptyCart(int cartId)
        {
            context.Carts.Include("Items").Single(x => x.Id==cartId).Items.Clear();
            context.SaveChanges();
        }

        public Cart GetCart(int customerId, int locationId)
        {
            CreateCartIfItDoesNotExist(customerId, locationId);
            return context.Carts.Single(x => x.CustomerId == customerId && x.LocationId == locationId);
        }

        public List<CartItem> GetCartItems(int cartId)
        {
            return context.CartItems.Include("Product").Where(x => x.CartId==cartId).ToList();
        }

        public List<Order> GetCustomerOrders(int customerId)
        {
            List<Order> orders = context.Orders.Where(x => x.CustomerId==customerId).ToList();
            foreach(Order o in orders)
            {
                o.Items = context.OrderItems.Include("Product").Where(x => x.OrderId == o.Id).ToList();
            }
            return orders;
        }

        public Customer GetDefaultCustomer()
        {
            if (!context.Customers.Any(x => true))
            {
                Customer customer = new Customer();
                customer.UserName = "Andres";
                customer.Address = new Address("123 Main Street", "Charles Town", "WV", 12345, "USA");
                context.Customers.Add(customer);
                context.SaveChanges();
            }
            return context.Customers.First(x => true);
        }

        public List<InvItem> GetInventory(int locationId)
        {
            return context.InvItems.Include("Product").Where(x => x.LocationId==locationId).ToList();
        }

        public Task<List<Location>> GetLocations()
        {
            return context.StoreLocations.Select(x => x).ToListAsync();
        }

        public List<Order> GetLocationOrders(int locationId)
        {
            List<Order> orders = context.Orders.Where(x => x.LocationId==locationId).ToList();
            foreach(Order o in orders)
            {
                o.Items = context.OrderItems.Include("Product").Where(x => x.OrderId == o.Id).ToList();
                o.CustomerAddress = context.Addresses.Single(x => x.Id == o.CustomerId);
            }
            return orders;
        }

        public void PlaceOrder(int locationId, int cartId, Order order)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                foreach(CartItem item in GetCartItems(cartId))
                {
                    ReduceInventory(locationId, item.ProductId, item.Quantity);
                }
                context.SaveChanges();
                EmptyCart(cartId);
                context.SaveChanges();
                context.Orders.Add(order);
                context.SaveChanges();
                transaction.Commit();
            }
        }

        public void RemoveCartItem(CartItem item)
        {
            context.CartItems.Remove(item);
            context.SaveChanges();
        }

        public void ReduceInventory(int locationId, int productId, int quantity)
        {
            context.InvItems.Single(x => x.LocationId==locationId && x.Product.Id==productId).Quantity -= quantity;
            context.SaveChanges();
        }
    }
}