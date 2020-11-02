using System.Collections.Generic;
using System.Threading.Tasks;
using StoreDB.Models;

namespace StoreDB
{
    
    public interface ILocationRepo
    {
        Location GetLocation();
        Task<List<InvItem>> GetInventory();
        void AddCartItem(CartItem item);
        void RemoveFromCart(int index);
        void EmptyCart();
        Task<Cart> GetCart();
        void RemoveInventory(InvItem invItem);
        void AddOrderToLocation(Order order);
        void AddNewProduct(InvItem invItem);
        void AddToProductQuantity(int index, int quantityAdded);
        void PlaceOrder(Order order);
    }
}