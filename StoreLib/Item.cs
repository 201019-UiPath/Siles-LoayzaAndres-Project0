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
        private float price;
        public float Price
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

        /// <summary>
        /// Description for product
        /// </summary>
        private string description;


        public Item(float price, int locId) 
        {
            this.id = this.GetHashCode();
            this.price = price;
            this.locId = locId;
        }

    }
}
