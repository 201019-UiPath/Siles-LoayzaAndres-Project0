using System;
using System.Collections.Generic;

namespace StoreDB.Models
{
    public class Cart
    {
        public int Id {get; set;}
        public int LocationId {get; set;}
        public int CustomerId {get; set;}
        public List<CartItem> Items {get; set;}

        public int Count { get{return Items.Count;} }

        public decimal Cost
        {
            get
            {
                decimal total = 0;
                foreach(var invItem in Items)
                {
                    total += (invItem.Quantity * invItem.Product.Price);
                }
                return total;
            }
        }

        public Cart()
        {
            Items = new List<CartItem>();
        }

        public void QuickWrite()
        {
            Console.WriteLine($"{Count} products in your cart.");
            foreach(var invItem in Items)
            {
                Console.WriteLine($"{invItem.Product.Name}");
                Console.WriteLine($"    Quantity: {invItem.Quantity}");
            }
            Console.WriteLine($"Subtotal: ${Cost}");
        }

        public void Write()
        {
            Console.WriteLine($"{Count} products in your cart.");
            int i = 0;
            foreach(var item in Items)
            {
                Console.Write($"[{i}] ");
                item.Write();
                i++;
            }
            Console.WriteLine($"Subtotal: ${Cost}");
        }
    }
}