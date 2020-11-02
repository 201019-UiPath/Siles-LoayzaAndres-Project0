namespace StoreDB.Models
{
    public abstract class Item
    {
        public int ProductId {get; set;}
        public Product Product {get; set;}
        public int Quantity {get; set;}
        
        public void Write()
        {
            Product.Write();
            System.Console.WriteLine($"    Quantity: {Quantity}");
        }
    }
}