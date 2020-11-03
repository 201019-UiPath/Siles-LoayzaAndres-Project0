using System.Collections.Generic;
using System.Threading.Tasks;
using StoreDB.Models;

namespace StoreDB
{
    
    public interface ILocationRepo
    {
        Location GetLocation();
        List<InvItem> GetInventory();
        void RemoveInventory(int productId, int quantity);
        void AddNewProduct(InvItem invItem);
        void AddToProductQuantity(int index, int quantityAdded);
    }
}