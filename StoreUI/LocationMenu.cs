using System;
using StoreLib;
using StoreBL;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace StoreUI
{
    internal class LocationMenu : Menu
    {
        private ILocation location;
        private ILocationBL locationBL;

        public LocationMenu(ILocation location)
        {
            this.location = location;
            this.locationBL = new LocationBL(location);
        }

        public override void Start()
        {
            do
            {
                Console.WriteLine($"\nWelcome to our {location.Name} location!");
                Console.WriteLine("Select from our stock.");
                Console.WriteLine("[0] View inventory");
                Console.WriteLine("[1] View cart");
                Console.WriteLine("[X] Back to Shop Menu");
                userInput = Console.ReadLine();
            } while (!UserInputIsX());
        }

        public override void StartAdmin()
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
                        WriteStock();
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

        protected void WriteStock()
        {
            Dictionary<string, Item> inventory = locationBL.GetInventory();
            foreach(var pair in inventory)
            {
                Item item = pair.Value;
                Console.WriteLine($"\n{item.Name}");
                Console.WriteLine($"    Price: ${item.Price}");
                Console.WriteLine($"    Description: {item.Description}");
                Console.WriteLine($"    In Stock: {item.NumOfStock}");
            }
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
            decimal itemPrice = decimal.Round(decimal.Parse(Console.ReadLine()), 2);
            Console.WriteLine("\nAdding new product...");
            Console.Write("Enter initial number of stock: ");
            int numOfStock = int.Parse(Console.ReadLine());

            Console.WriteLine("\nConfirm new product (Y/N)?");
            Console.WriteLine($"    Name: {itemName}");
            Console.WriteLine($"    Description: {itemDescript}");
            Console.WriteLine($"    Price: ${itemPrice}");
            Console.WriteLine($"    Number of stock: {numOfStock}");
            string confirm = Console.ReadLine();
            if (Regex.IsMatch(confirm, "y|Y"))
            {
                locationBL.AddItem(new Item(itemPrice, location.Id, itemName, itemDescript, numOfStock));
                Console.WriteLine("New product added!");
            }
            else
            {
                Console.WriteLine("New product cancelled. Press any key to go back.");
                Console.Read();
            }
            
        }
    }
}