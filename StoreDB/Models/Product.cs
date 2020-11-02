using System;

namespace StoreDB.Models
{
    /// <summary>
    /// Represents an individual product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// ID number for this Product
        /// </summary>
        public int Id {get; set;}

        /// <summary>
        /// Price in USD for this product
        /// </summary>
        private decimal price;
        public decimal Price { get{return price;} set{price=decimal.Round(value, 2);} }

        /// <summary>
        /// Short descriptive name for product
        /// </summary>
        public string Name {get; set;}

        /// <summary>
        /// Description for product
        /// </summary>
        public string Description {get; set;}

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else if ( Name != ((Product)obj).Name )
            {
                return false;
            }

            return true;
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public void Write()
        {
            Console.WriteLine($"{this.Name}");
            Console.WriteLine($"    Price: ${this.Price}");
            Console.WriteLine($"    Description: {this.Description}");
        }

    }
}
