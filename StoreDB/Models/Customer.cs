using System.Collections.Generic;

namespace StoreDB.Models
{
    public class Customer
    {
        public int Id {get; set;}
        public string UserName {get; set;}
        public Address Address {get; set;}
        public List<Order> Orders {get; set;}

        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}