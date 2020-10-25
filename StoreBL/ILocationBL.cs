using StoreLib;
using System.Collections.Generic;

namespace StoreBL
{
    public interface ILocationBL
    {
        Dictionary<string, Item> GetInventory();

         void AddItem(Item item);

         bool HasItem (string name);

         void AddStock(string name, int add);
    }
}