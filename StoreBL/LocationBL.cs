using System;
using System.Collections.Generic;
using StoreLib;
using StoreDB;

namespace StoreBL
{
    public class LocationBL : ILocationBL
    {
        private Location location;
        private Dictionary<string, Product> inventory;
        private HashSet<Product> products;
        private Cart cart;

        public LocationBL(Location location)
        {
            this.location = location;
            inventory = LocationRepo.GetInventory();
            cart = new Cart();
        }

        public int GetInventoryCount()
        {
            return this.inventory.Count;
        }

        public string[] GetAllProductKeys()
        {
            string[] productKeys = new string[inventory.Count];
            int i=0;
            foreach(var pair in inventory)
            {
                productKeys[i] = pair.Value.Name;
                i++;
            }
            return productKeys;
        }

        public void AddProductToInventory(Product product)
        {
            if (!inventory.ContainsKey(product.Name))
            {
                inventory.Add(product.Name, product);
            }
            else {
                System.Console.WriteLine("Error! Product already exists!");
            }
        }

        public void WriteInventory()
        {
            int i=0;
            foreach(var pair in inventory)
            {
                Console.Write($"[{i}] ");
                pair.Value.Write();
                i++;
            }
        }

        public bool HasProduct(string name)
        {
            return inventory.ContainsKey(name);
        }

        public void AddProductToCart(string key, int amount)
        {
            if (amount>inventory[key].NumOfStock)
            {
                throw new ArgumentException("Not enough stock in inventory.");
            }
            cart.AddProduct(inventory[key], amount); //add stock to cart
            inventory[key].NumOfStock -= amount; //reduce stock
        }

        public void WriteCart()
        {
            cart.Write();
        }

        public void AddStock(string name, int add)
        {
            if (HasProduct(name))
            {
                inventory[name].AddStock(add);
            }
            else
            {
                System.Console.WriteLine("Error! Product not found!");
            }
        }
    }
}