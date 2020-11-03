namespace StoreDB.Models
{
    public class Address
    {
        public int Id {get; set;}
        public string Street {get; set;}
        public string City {get; set;}
        public int Zip {get; set;}
        public string State {get; set;}
        public string Country {get; set;}

        public Address(){}

        public Address(string street, string city, string state, int zip, string country)
        {
            this.Street = street;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.Country = country;
        }

        public override string ToString()
        {
            return $"{Street} {City}, {State} {Zip}, {Country}";
        }
    }
}