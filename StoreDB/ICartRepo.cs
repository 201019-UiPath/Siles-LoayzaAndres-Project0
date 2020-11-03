using System.Collections.Generic;
using StoreDB.Models;

namespace StoreDB
{
    public interface ICartRepo
    {
        void AddCartItem(CartItem item);
        void RemoveCartItem(CartItem item);
        void EmptyCart(int cartId);
        Cart GetCart(int customerId, int locationId);
        List<CartItem> GetCartItems(int cartId);
        void PlaceOrder(int locationId, int cartId, Order order);
    }
}