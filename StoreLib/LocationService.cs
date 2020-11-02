using System;
using System.Collections.Generic;
using StoreDB;
using StoreDB.Models;

namespace StoreLib
{
    /// <summary>
    /// Provides service for a specific location, based on the LocationRepo
    /// given in the constructor. The business logic for accessing a location's
    /// inventory and order history is contained here.
    /// </summary>
    public class LocationService
    {
        private ILocationRepo repo;

        public LocationService(ILocationRepo repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Returns the name of this Location.
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return repo.GetLocation().Name;
        }

        public void AddNewProductToInventory(InvItem invItem)
        {
            if (!HasProduct(invItem.Product))
            {
                repo.AddNewProduct(invItem);
            }
            else {
                System.Console.WriteLine("Error! Product already exists!");
            }
        }

        public void WriteInventory()
        {
            List<InvItem> inventory = repo.GetInventory().Result;
            int i=0;
            foreach(var item in inventory)
            {
                Console.Write($"[{i}] ");
                item.Write();
                i++;
            }
        }

        /// <summary>
        /// Returns true if the given Product exists already in this Location's
        /// Inventory. Iterates through Inventory and compares the Product in
        /// each InvItem with the given Product using the Equals method.
        /// </summary>
        /// <param name="product"></param>
        /// <returns>true if given Product is in this Inventory</returns>
        public bool HasProduct(Product product)
        {
            List<InvItem> inventory = repo.GetInventory().Result;
            foreach(var invItem in inventory)
            {
                if(invItem.Product.Equals(product))
                {
                    return true;
                }
            }
            return false;
        }

        public Product GetProductByIndex(int index)
        {
            return repo.GetInventory().Result[index].Product;
        }

        public void AddToInvItem(int index, int quantityAdded)
        {
            if (index<repo.GetInventory().Result.Count)
            {
                repo.AddToProductQuantity(index, quantityAdded);
            }
            else
            {
                System.Console.WriteLine("Error! Product not found!");
            }
        }
    }
}