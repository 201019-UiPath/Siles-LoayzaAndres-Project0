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

        public Location()
        {

        }

        public Location(int id, string name, Address address)
        {
            this.id = id;
            this.name = name;
            this.locAddress = address;
        }

    }
}