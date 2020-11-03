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
        public DateTime DateTime {get; set;}
        public List<OrderItem> Items {get; set;}
        public decimal Cost {get; set;}

        public Order()
        {
            Items = new List<OrderItem>();
        }

        public void Write()
        {
            Console.WriteLine($"Order ID: {Id}");
            Console.WriteLine($"Date: {DateTime.ToShortDateString()}");
            Console.WriteLine($"Time: {DateTime.ToShortTimeString()}");
            foreach(OrderItem item in Items)
            {
                Console.WriteLine($"    {item.Quantity} of {item.Product.Name}");
            }
            //Console.WriteLine($"    Destination: {CustomerAddress}");
            Console.WriteLine($"    Total Cost: ${Cost}");
        }
    }
}