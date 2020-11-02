namespace StoreDB.Models
{
    public class InvItem : Item
    {
        public int LocationId {get; set;}

        public InvItem() {}
        
        public InvItem(Product product, int quantity)
        {
            ProductId = product.Id;
            Product = product;
            Quantity = quantity;
        }
    }
}