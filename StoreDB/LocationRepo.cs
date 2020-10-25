using System.Collections.Generic;
using StoreLib;

namespace StoreDB
{
    public static class LocationRepo
    {
        public static Dictionary<string, Item> GetInventory(int locationId)
        {
            Dictionary<string, Item> inventory = new Dictionary<string, Item>();
            inventory.Add("Apple", new Item(System.Convert.ToDecimal(1.99), 0, "Apple", "This is an apple.", 30));

            return inventory;
        }
    }
}