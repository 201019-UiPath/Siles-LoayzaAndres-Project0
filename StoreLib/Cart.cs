using System;
using System.Collections.Generic;

namespace StoreLib
{
    public class Cart
    {
        Dictionary<string, Product> products;
        public int Count
        {
            get
            {
                return products.Count;
            }
        }

        public Cart()
        {
            products = new Dictionary<string, Product>();
        }

        public void AddProduct(Product product, int numOfProduct)
        {
            //if product is already in cart, add num of product to stock
            if (products.ContainsKey(product.Name))
            {
                products[product.Name].NumOfStock += numOfProduct;
            }
            //if product is not already in cart, add product
            else
            {
                product.NumOfStock = numOfProduct;
                products.Add(product.Name, product);
            }
        }

        public void Write()
        {
            Console.WriteLine($"{Count} products in your cart.");
            foreach(var pair in products)
            {
                pair.Value.Write();
            }
        }
    }
}