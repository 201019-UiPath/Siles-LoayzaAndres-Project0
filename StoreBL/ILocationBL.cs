using StoreLib;
using System.Collections.Generic;

namespace StoreBL
{
    public interface ILocationBL
    {
        int GetInventoryCount();

        string[] GetAllItemKeys();

        void AddItemToInventory(Item item);

        void WriteInventory();

        bool HasItem (string name);

        void AddItemToCart(string key, int amount);

        void WriteCart();

        void AddStock(string name, int add);
    }
}