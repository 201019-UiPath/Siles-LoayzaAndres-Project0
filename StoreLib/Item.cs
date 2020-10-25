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
        /// ID number of Location associated with this product
        /// </summary>
        private int locId;
        public int LocId
        {
            get {
                return locId;
            }
            set {
                locId = value;
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
        }


        public Item(decimal price, int locId, string name, string description, int numOfStock) 
        {
            this.id = this.GetHashCode();
            this.price = price;
            this.locId = locId;
            this.name = name;
            this.description = description;
            this.numOfStock = numOfStock;
        }

        public void AddStock(int add)
        {
            this.numOfStock += add;
        }

    }
}
