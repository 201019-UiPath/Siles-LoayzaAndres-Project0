using System;
using System.Collections.Generic;

namespace StoreDB.Models
{
    public class Order
    {
        public int Id {get; set;}
        public int LocationId {get; set;}
        public int CustomerId {get; set;}
        public Address LocationAddress {get; set;}
        public Address CustomerAddress {get; set;}
        public List<OrderItem> Items {get; set;}
        public decimal Cost {get; set;}

        public void Write()
        {
            Console.WriteLine($"Order ID: {Id}");
            foreach(OrderItem item in Items)
            {
                Console.WriteLine($"    {item.Quantity} of {item.Product.Name}");
            }
            Console.WriteLine($"    Destination: {CustomerAddress}");
            Console.WriteLine($"    Total Cost: ${Cost}");
        }
    }
}