using System.Collections.Generic;

namespace StoreDB.Models
{
    public class Customer
    {
        public int Id {get; private set;}
        public string UserName {get; set;}
        public Address Address {get; set;}
        public List<Order> Orders {get; set;}

        public Customer(){}

        public Customer(int id)
        {
            this.Id = id;
            this.Orders = new List<Order>();
        }
    }
}