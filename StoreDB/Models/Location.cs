using System.Collections.Generic;

namespace StoreDB.Models
{
    /// <summary>
    /// Represents a store location, including address, inventory, and order
    /// history.
    /// </summary>
    public class Location
    {
        public int Id {get; set;}

        /// <summary>
        /// Name of location used in UI
        /// </summary>
        public string Name {get; set;}

        /// <summary>
        /// Address for this store's location.
        /// </summary>
        public Address Address {get; set;}

        /// <summary>
        /// List of all available products at this store
        /// </summary>
        /// <value></value>
        public List<InvItem> Inventory {get; set;}

        public List<Order> Orders {get; set;}

        //public Dictionary<int, Cart> Carts {get; set;}

    }
}