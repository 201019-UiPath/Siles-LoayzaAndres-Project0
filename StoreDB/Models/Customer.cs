using System.Collections.Generic;

namespace StoreDB.Models
{
    public class Customer
    {
        public List<Order> Orders {get; set;}
    }
}