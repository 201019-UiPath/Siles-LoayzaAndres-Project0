using System;
using System.Collections.Generic;
using StoreDB;

namespace StoreLib
{
    public class LocationService
    {
        private Location location;

        public LocationService(Location location)
        {
            this.location = location;
            this.location.Inventory = LocationRepo.GetInventory();
        }

        public int GetInventoryCount()
        {
            return this.location.Inventory.Count;
        }

        public void AddNewProductToInventory(Stock stock)
        {
            if (!HasProduct(stock.Product))
            {
                location.Inventory.Add(stock);
            }
            else {
                System.Console.WriteLine("Error! Product already exists!");
            }
        }

        public void WriteInventory()
        {
            int i=0;
            foreach(var stock in location.Inventory)
            {
                Console.Write($"[{i}] ");
                stock.Write();
                i++;
            }
        }

        /// <summary>
        /// Returns true if the given Product exists already in this Location's
        /// Inventory. Iterates through Inventory and compares the Product in
        /// each Stock with the given Product using the Equals method.
        /// </summary>
        /// <param name="product"></param>
        /// <returns>true if given Product is in this Inventory</returns>
        public bool HasProduct(Product product)
        {
            foreach(var stock in location.Inventory)
            {
                if(stock.Product.Equals(product))
                {
                    return true;
                }
            }
            return false;
        }

        public Product GetProductByIndex(int index)
        {
            return location.Inventory[index].Product;
        }

        public void AddToStock(int index, int quantityAdded)
        {
            if (index<location.Inventory.Count)
            {
                location.Inventory[index].Quantity += quantityAdded;
            }
            else
            {
                System.Console.WriteLine("Error! Product not found!");
            }
        }
    }
}