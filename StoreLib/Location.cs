namespace StoreLib
{
    /// <summary>
    /// Represents a store location, including address, inventory, and order
    /// history.
    /// </summary>
    public class Location
    {
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
        /// Address for this store's location.
        /// </summary>
        private Address locAddress;
        public Address LocAddress
        {
            get
            {
                return locAddress;
            }
        }

        public Location(string name, Address address)
        {
            this.name = name;
            this.locAddress = address;
        }

    }
}