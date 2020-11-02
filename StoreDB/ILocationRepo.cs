using System.Collections.Generic;
using StoreDB.Models;

namespace StoreDB
{
    
    public interface ILocationRepo
    {
        Location GetLocation();
        List<Stock> GetInventory();
        void AddToCart(Stock stock);
        void RemoveFromCart(int index);
        void EmptyCart();
        Cart GetCart();
        void RemoveInventory(Stock stock);
        void AddOrderToLocation(Order order);
        void AddNewProduct(Stock stock);
        void AddToProductQuantity(int index, int quantityAdded);
    }
}