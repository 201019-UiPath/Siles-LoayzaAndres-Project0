using StoreDB.Models;

namespace StoreDB
{
    public interface ICartRepo
    {
        void AddCartItem(CartItem item);
        void RemoveProductFromCart(int productId);
        void EmptyCart();
        Cart GetCart();
        void PlaceOrder(Order order);
    }
}