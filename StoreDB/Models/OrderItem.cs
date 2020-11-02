namespace StoreDB.Models
{
    public class OrderItem : Item
    {
        public int OrderId {get; set;}

        public OrderItem() {}

        public OrderItem(Product product, int quantity)
        {
            this.ProductId = product.Id;
            this.Product = product;
            this.Quantity = quantity;
        }
    }
}