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

        public void AddNewProductToInventory(Stock stock)
        {
            if (!HasProduct(stock.Product))
            {
                repo.AddNewProduct(stock);
            }
            else {
                System.Console.WriteLine("Error! Product already exists!");
            }
        }

        public void WriteInventory()
        {
            List<Stock> inventory = repo.GetInventory();
            int i=0;
            foreach(var stock in inventory)
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
            List<Stock> inventory = repo.GetInventory();
            foreach(var stock in inventory)
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
            return repo.GetInventory()[index].Product;
        }

        public void AddToStock(int index, int quantityAdded)
        {
            if (index<repo.GetInventory().Count)
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