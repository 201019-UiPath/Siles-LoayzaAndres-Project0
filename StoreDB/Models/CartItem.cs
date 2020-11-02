
namespace StoreDB.Models
{
    public class CartItem : Item
    {
        public int CartId {get; set;}
        public CartItem() {}

        public CartItem(Product product, int quantity)
        {
            this.ProductId = product.Id;
            this.Product = product;
            this.Quantity = quantity;
        }
    }
}