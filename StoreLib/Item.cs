using System;

namespace StoreLib
{
    /// <summary>
    /// Represents an individual product
    /// </summary>
    public class Item
    {
        /// <summary>
        /// ID number for this Item
        /// </summary>
        private int id;
        public int Id
        {
            get {
                return id;
            }
            set {
                id = value;
            }
        }

        /// <summary>
        /// Price in USD for this item
        /// </summary>
        private decimal price;
        public decimal Price
        {
            get {
                return price;
            }
            set {
                price = value;
            }
        }

        /// <summary>
        /// Short descriptive name for product
        /// </summary>
        private string name;
        public string Name 
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Description for product
        /// </summary>
        private string description;
        public string Description
        {
            get
            {
                return description;
            }
        }

        private int numOfStock;
        public int NumOfStock
        {
            get
            {
                return numOfStock;
            }
            set
            {
                numOfStock = value;
            }
        }


        public Item(decimal price, string name, string description, int numOfStock) 
        {
            this.id = this.GetHashCode();
            this.price = decimal.Round(price, 2);
            this.name = name;
            this.description = description;
            this.numOfStock = numOfStock;
        }

        public void AddStock(int add)
        {
            this.numOfStock += add;
        }

        public void Write()
        {
            Console.WriteLine($"{this.name}");
            Console.WriteLine($"    Price: ${this.Price}");
            Console.WriteLine($"    Description: {this.Description}");
            Console.WriteLine($"    In Stock: {this.NumOfStock}");
        }

    }
}
