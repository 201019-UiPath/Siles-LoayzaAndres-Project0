using StoreDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreDB
{
    /// <summary>
    /// Generates hard-coded data. Used for testing
    /// </summary>
    public class FalseRepo : IRepo
    {
        private List<Location> locations;
        private Customer customer;
        private Location location;

        public FalseRepo()
        {
            InitLocations();
        }

        private void InitLocations()
        {
            locations = new List<Location>();
            locations.Add(new Location(0, "Washington, DC", new Address("123 Main St", "Washington", 12345, "DC", "USA")));
            locations.Add(new Location(1, "Sterling, VA", new Address("123 Main St", "Sterling", 12345, "VA", "USA")));
            locations.Add(new Location(2, "Frederick, MD", new Address("123 Main St", "Frederick", 12345, "MD", "USA")));   
        }

        public bool HasLocation(int index)
        {
            return index < locations.Count;
        }

        public List<Location> GetLocations()
        { 
            return locations;
        }

        public IShopRepo SetCurrentCustomer(int index)
        {
            this.customer = new Customer(index);
            return this;
        }

        /// <summary>
        /// Finds the specified location based on its index. Sets this location
        /// to that and returns this.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>this object with location set</returns>
        public ILocationRepo SetCurrentLocation(int index)
        {
            InitLocations();
            this.location = locations[index];
            this.location.Inventory.Add(new Stock(new Product(1.99M, "Apple", "This is an apple."), 30) );
            return this;
        }

        public List<Order> GetCustomerOrders()
        {
            return this.customer.Orders;
        }

        public Customer GetCustomer()
        {
            return this.customer;
        }

        public void AddOrderToCustomer(Order order)
        {
            this.customer.Orders.Add(order);
        }

        public Location GetLocation()
        {
            return this.location;
        }

        public List<Stock> GetInventory()
        {
            return this.location.Inventory;
        }

        public void RemoveInventory(Stock stock)
        {
            foreach(Stock s in this.location.Inventory)
            {
                if (s.Product.Name == stock.Product.Name)
                {
                    s.Quantity -= stock.Quantity;
                }
            }
        }

        public void AddOrderToLocation(Order order)
        {
            this.location.Orders.Add(order);
        }

        public void AddToCart(Stock stock)
        {
            if (!location.Carts.ContainsKey(customer.Id))
            {
                location.Carts.Add(customer.Id, new Cart());
            }
            location.Carts[customer.Id].Products.Add(stock);
        }

        public void RemoveFromCart(int index)
        {
            if (!location.Carts.ContainsKey(customer.Id))
            {
                location.Carts.Add(customer.Id, new Cart());
            }
            location.Carts[customer.Id].Products.RemoveAt(index);
        }

        public void EmptyCart()
        {
            if (!location.Carts.ContainsKey(customer.Id))
            {
                location.Carts.Add(customer.Id, new Cart());
            }
            location.Carts[customer.Id].Products.Clear();
        }

        public Cart GetCart()
        {
            if (!location.Carts.ContainsKey(customer.Id))
            {
                location.Carts.Add(customer.Id, new Cart());
            }
            return location.Carts[customer.Id];
        }

        public void AddNewProduct(Stock stock)
        {
            this.location.Inventory.Add(stock);
        }

        public void AddToProductQuantity(int index, int quantityAdded)
        {
            this.location.Inventory[index].Quantity += quantityAdded;
        }
    }
}