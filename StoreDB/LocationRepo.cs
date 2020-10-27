using System.Collections.Generic;
using StoreLib;

namespace StoreDB
{
    public static class LocationRepo
    {
        public static Dictionary<string, Product> GetInventory()
        {
            Dictionary<string, Product> inventory = new Dictionary<string, Product>();
            inventory.Add("Apple", new Product(1.99M, "Apple", "This is an apple.", 30));

            return inventory;
        }
    }
}