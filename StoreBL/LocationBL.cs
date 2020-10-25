using System.Collections.Generic;
using StoreLib;
using StoreDB;

namespace StoreBL
{
    public class LocationBL : ILocationBL
    {
        private ILocation location;
        private Dictionary<string, Item> inventory;

        public LocationBL(ILocation location)
        {   
            this.location = location;
            inventory = GetInventory();
        }

        public Dictionary<string, Item> GetInventory()
        {
            return LocationRepo.GetInventory(location.Id);
        }

        public void AddItem(Item item)
        {
            if (!inventory.ContainsKey(item.Name))
            {
                inventory.Add(item.Name, item);
            }
            else {
                //SHOULD ADD EXCEPTION HERE
                System.Console.WriteLine("Error! Product already exists!");
            }
        }

        public bool HasItem(string name)
        {
            return inventory.ContainsKey(name);
        }

        public void AddStock(string name, int add)
        {
            if (HasItem(name))
            {
                inventory[name].AddStock(add);
            }
            else
            {
                //SHOULD ADD EXCEPTION HERE
                System.Console.WriteLine("Error! Product not found!");
            }
        }
    }
}