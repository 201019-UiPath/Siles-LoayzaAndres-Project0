namespace StoreDB
{
    public class Stock
    {
        public Product Product {get; private set;}
        public int Quantity {get; set;}
        public Stock(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public void Write()
        {
            Product.Write();
            System.Console.WriteLine($"    Quantity: {Quantity}");
        }
    }
}