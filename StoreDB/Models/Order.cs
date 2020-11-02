using System;
using System.Collections.Generic;

namespace StoreDB.Models
{
    public class Order
    {
        public int Id {get; set;}
        public int LocationId {get; private set;}
        public int CustomerId {get; private set;}
        public Address LocationAddress {get; private set;}
        public Address CustomerAddress {get; private set;}
        public List<Stock> Products {get; set;}
        public decimal Cost {get; private set;}

        public Order(int locId, int customId, Address locAd, Address customAd, List<Stock> products, decimal cost)
        {
            this.LocationId = locId;
            this.CustomerId = customId;
            this.LocationAddress = locAd;
            this.CustomerAddress = customAd;
            this.Products = products;
            this.Cost = cost;
        }

        public void Write()
        {
            Console.WriteLine($"Order ID: {Id}");
            foreach(Stock s in Products)
            {
                Console.WriteLine($"    {s.Quantity} of {s.Product.Name}");
            }
            Console.WriteLine($"    Destination: {CustomerAddress}");
            Console.WriteLine($"    Total Cost: ${Cost}");
        }
    }
}