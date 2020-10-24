namespace StoreLib
{
    /// <summary>
    /// Represents a store location, including address, inventory, and order
    /// history.
    /// </summary>
    public class Location : ILocation
    {
        /// <summary>
        /// ID number for the store location
        /// </summary>
        private int id;
        public int Id 
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Name of location used in UI
        /// </summary>
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Inventory for all items in this location
        /// </summary>
        private Inventory locInventory;
        public Inventory LocInventory {get; set;}

        private Address locAddress;

        public Location(string name)
        {
            this.name = name;
            //this.LocInventory = inventory;
        }

    }
}