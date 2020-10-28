using System.Collections.Generic;

namespace StoreDB
{
    /// <summary>
    /// Represents a store location, including address, inventory, and order
    /// history.
    /// </summary>
    public class Location
    {
        public int Id {get; private set;}

        /// <summary>
        /// Name of location used in UI
        /// </summary>
        public string Name {get; private set;}

        /// <summary>
        /// Address for this store's location.
        /// </summary>
        public Address Address {get; private set;}

        /// <summary>
        /// List of all available products at this store
        /// </summary>
        /// <value></value>
        public List<Stock> Inventory {get; set;}

        public List<Order> Orders {get; set;}

        public Location(string name, Address address)
        {
            this.Name = name;
            this.Address = address;
            this.Inventory = new List<Stock>();
            this.Orders = new List<Order>();
        }

    }
}