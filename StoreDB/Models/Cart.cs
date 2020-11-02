using System;
using System.Collections.Generic;

namespace StoreDB.Models
{
    public class Cart
    {
        public List<Stock> Products {get; set;}

        public int Count
        {
            get
            {
                return Products.Count;
            }
        }

        public decimal Cost
        {
            get
            {
                decimal total = 0;
                foreach(var stock in Products)
                {
                    total += (stock.Quantity * stock.Product.Price);
                }
                return total;
            }
        }

        public Cart()
        {
            Products = new List<Stock>();
        }

        public void QuickWrite()
        {
            Console.WriteLine($"{Count} products in your cart.");
            foreach(var stock in Products)
            {
                Console.WriteLine($"{stock.Product.Name}");
                Console.WriteLine($"    Quantity: {stock.Quantity}");
            }
            Console.WriteLine($"Subtotal: ${Cost}");
        }

        public void Write()
        {
            Console.WriteLine($"{Count} products in your cart.");
            int i = 0;
            foreach(var stock in Products)
            {
                Console.Write($"[{i}] ");
                stock.Write();
                i++;
            }
            Console.WriteLine($"Subtotal: ${Cost}");
        }
    }
}