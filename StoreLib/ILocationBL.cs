using StoreDB;
using System.Collections.Generic;

namespace StoreLib
{
    public interface ILocationBL
    {
        int GetInventoryCount();

        string[] GetAllProductKeys();

        void AddProductToInventory(Product product);

        void WriteInventory();

        bool HasProduct (string name);

        void AddProductToCart(string key, int amount);

        void WriteCart();

        void AddStock(string name, int add);
    }
}