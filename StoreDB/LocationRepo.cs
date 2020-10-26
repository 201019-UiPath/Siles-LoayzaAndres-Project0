using System.Collections.Generic;
using StoreLib;

namespace StoreDB
{
    public static class LocationRepo
    {
        public static Dictionary<string, Item> GetInventory()
        {
            Dictionary<string, Item> inventory = new Dictionary<string, Item>();
            inventory.Add("Apple", new Item(1.99M, "Apple", "This is an apple.", 30));

            return inventory;
        }
    }
}