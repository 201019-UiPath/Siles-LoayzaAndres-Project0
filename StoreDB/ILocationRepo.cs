using System.Collections.Generic;
using System.Threading.Tasks;
using StoreDB.Models;

namespace StoreDB
{
    
    public interface ILocationRepo
    {
        List<InvItem> GetInventory(int locationId);
        void ReduceInventory(int locationId, int productId, int quantity);
        void AddNewProduct(InvItem invItem);
        void AddToProductQuantity(int locationId, int productId, int quantityAdded);
        List<Order> GetLocationOrders(int locationId);
    }
}