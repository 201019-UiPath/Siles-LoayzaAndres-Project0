using System;
using System.Collections.Generic;
using StoreLib;
using StoreDB;

namespace StoreBL
{
    public class LocationBL : ILocationBL
    {
        private ILocation location;
        private Dictionary<string, Item> inventory;
        private ICart cart;

        public LocationBL(ILocation location)
        {   
            this.location = location;
            inventory = LocationRepo.GetInventory();
            cart = new Cart();
        }

        public int GetInventoryCount()
        {
            return this.inventory.Count;
        }

        public string[] GetAllItemKeys()
        {
            string[] itemKeys = new string[inventory.Count];
            int i=0;
            foreach(var pair in inventory)
            {
                itemKeys[i] = pair.Value.Name;
                i++;
            }
            return itemKeys;
        }

        public void AddItemToInventory(Item item)
        {
            if (!inventory.ContainsKey(item.Name))
            {
                inventory.Add(item.Name, item);
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

        public bool HasItem(string name)
        {
            return inventory.ContainsKey(name);
        }

        public void AddItemToCart(string key, int amount)
        {
            if (amount>inventory[key].NumOfStock)
            {
                throw new ArgumentException("Not enough stock in inventory.");
            }
            cart.AddItem(inventory[key], amount); //add stock to cart
            inventory[key].NumOfStock -= amount; //reduce stock
        }

        public void WriteCart()
        {
            cart.Write();
        }

        public void AddStock(string name, int add)
        {
            if (HasItem(name))
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