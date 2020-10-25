namespace StoreLib
{
    public class Address
    {
        private string street;
        public string Street
        {
            get
            {
                return street;
            }
        }

        private string city;
        public string City
        {
            get
            {
                return city;
            }
        }

        private int zip;
        public int Zip
        {
            get
            {
                return zip;
            }
        }

        private string state;
        public string State
        {
            get
            {
                return state;
            }
        }

        private string country;
        public string Country
        {
            get
            {
                return country;
            }
        }

        public Address()
        {
            this.street = "123 Main Street";
            this.city = "Central City";
            this.zip = 12345;
            this.state = "NY";
            this.country = "USA";
        }

        public Address(string street, string city, int zip, string state, string country)
        {
            this.street = street;
            this.city = city;
            this.zip = zip;
            this.state = state;
            this.country = country;
        }
    }
}