using System;
using System.Collections.Generic;

namespace StoreDB
{
    public class Cart
    {
        List<Stock> products;
        public int Count
        {
            get
            {
                return products.Count;
            }
        }

        public Cart()
        {
            products = new List<Stock>();
        }

        /*
        public void AddProduct(Product product, int numOfProduct)
        {
            //if product is already in cart, add num of product to stock
            if (!location.HasProduct(stock.Product))
            {
                location.Inventory.Add(stock);
            }
            else {
                System.Console.WriteLine("Error! Product already exists!");
            }
        }
        */

        public void Write()
        {
            Console.WriteLine($"{Count} products in your cart.");
            foreach(var stock in products)
            {
                stock.Write();
            }
        }
    }
}