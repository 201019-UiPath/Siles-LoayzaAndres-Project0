using System;
using StoreDB;
using System.Text.RegularExpressions;

namespace StoreUI
{
    internal class AdminLocationMenu : LocationMenu
    {
        public AdminLocationMenu(Location location) : base(location){}
        
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
                        locationService.WriteInventory();
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
            locationService.WriteInventory();
            do 
            {
                Console.WriteLine("\nSelect a product to add stock. Enter X to go back.");
                userInput = Console.ReadLine();
                Product product;
                if(UserInputIsInt())
                {
                    try
                    {
                        int productIndex = int.Parse(userInput);
                        product = locationService.GetProductByIndex(productIndex);
                        Console.WriteLine($"\nAdding stock to {product.Name}.");
                        Console.Write("Enter amount of stock being added: ");
                        int quantityAdded = int.Parse(Console.ReadLine());
                        locationService.AddToStock(productIndex, quantityAdded);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Failed to add stock.");
                    }
                }
                else 
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }
            } while (!UserInputIsX());
            userInput = "";
        }

        protected void AddNewProduct()
        {
            Console.WriteLine("\nAdding new product...");
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            Console.WriteLine("\nAdding new product...");
            Console.Write("Enter product description: ");
            string productDescript = Console.ReadLine();
            Console.WriteLine("\nAdding new product...");
            Console.Write("Enter product price: $");
            decimal productPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("\nAdding new product...");
            Console.Write("Enter initial quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Stock newStock = new Stock(new Product(productPrice, productName, productDescript), quantity);

            Console.WriteLine("\nConfirm new product (Y/N)?");
            newStock.Write();
            string confirm = Console.ReadLine();
            if (Regex.IsMatch(confirm, "y|Y"))
            {
                locationService.AddNewProductToInventory(newStock);
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