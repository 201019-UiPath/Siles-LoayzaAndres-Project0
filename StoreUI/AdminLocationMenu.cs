using System;
using StoreLib;
using System.Text.RegularExpressions;

namespace StoreUI
{
    internal class AdminLocationMenu : LocationMenu
    {
        public AdminLocationMenu(ILocation location) : base(location){}
        
        public override void Start()
        {
            do
            {
                Console.WriteLine($"\nWelcome to our {location.Name} location, admin!");
                Console.WriteLine("[0] View inventory");
                Console.WriteLine("[1] Add stock");
                Console.WriteLine("[2] Add new product");
                Console.WriteLine("[X] Back to location select");
                userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "0":
                        locationBL.WriteInventory();
                        break;
                    case "1":
                        AddStock();
                        break;
                    case "2":
                        AddNewProduct();
                        break;
                }
            } while (!UserInputIsX());
        }

        protected void AddStock()
        {
            Console.WriteLine("\nAdding stock to existing product...");
            Console.Write("Enter product name exactly: ");
            string itemName = Console.ReadLine();
            if (locationBL.HasItem(itemName))
            {
                Console.WriteLine($"\nAdding stock to {itemName}...");
                Console.Write("Enter amount of stock being added: ");
                int stockAdded = int.Parse(Console.ReadLine());
                locationBL.AddStock(itemName, stockAdded);
            }
            else 
            {
                Console.WriteLine("Product not found. Press any key to go back.");
                Console.Read();
            }
            userInput = "";
        }

        protected void AddNewProduct()
        {
            Console.WriteLine("\nAdding new product...");
            Console.Write("Enter product name: ");
            string itemName = Console.ReadLine();
            Console.WriteLine("\nAdding new product...");
            Console.Write("Enter product description: ");
            string itemDescript = Console.ReadLine();
            Console.WriteLine("\nAdding new product...");
            Console.Write("Enter product price: $");
            decimal itemPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("\nAdding new product...");
            Console.Write("Enter initial number of stock: ");
            int numOfStock = int.Parse(Console.ReadLine());

            Item newItem = new Item(itemPrice, itemName, itemDescript, numOfStock);

            Console.WriteLine("\nConfirm new product (Y/N)?");
            newItem.Write();
            string confirm = Console.ReadLine();
            if (Regex.IsMatch(confirm, "y|Y"))
            {
                locationBL.AddItemToInventory(newItem);
                Console.WriteLine("New product added!");
            }
            else
            {
                Console.WriteLine("New product cancelled. Press any key to go back.");
                Console.Read();
            }
            userInput = "";
        }
    }
}