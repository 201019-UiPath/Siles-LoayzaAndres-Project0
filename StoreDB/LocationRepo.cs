using System.Collections.Generic;
using StoreDB;

namespace StoreDB
{
    public static class LocationRepo
    {
        public static List<Stock> GetInventory()
        {
            List<Stock> inventory = new List<Stock>();
            inventory.Add(new Stock(new Product(1.99M, "Apple", "This is an apple."), 30) );

            return inventory;
        }
    }
}