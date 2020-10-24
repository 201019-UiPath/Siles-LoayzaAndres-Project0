namespace StoreLib
{
    public class Address
    {
        private string street;
        private string city;
        private int zip;
        private string state;
        private string country;

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