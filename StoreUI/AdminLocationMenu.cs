using System;
using StoreDB;
using System.Text.RegularExpressions;
using StoreDB.Models;

namespace StoreUI
{
    internal class AdminLocationMenu : LocationMenu
    {
        public AdminLocationMenu(ILocationRepo repo) : base(repo){}
        
        public override void Start()
        {
            do
            {
                Console.WriteLine($"\nWelcome to our {locationService.GetName()} location, admin!");
                Console.WriteLine("[0] View inventory");
                Console.WriteLine("[1] Add quantity");
                Console.WriteLine("[2] Add new product");
                Console.WriteLine("[X] Back to location select");
                userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "0":
                        locationService.WriteInventory();
                        break;
                    case "1":
                        AddInvItem();
                        break;
                    case "2":
                        AddNewProduct();
                        break;
                }
            } while (!UserInputIsX());
        }

        protected void AddInvItem()
        {
            locationService.WriteInventory();
            do 
            {
                Console.WriteLine("\nSelect a product to add quantity. Enter X to go back.");
                userInput = Console.ReadLine();
                Product product;
                if(UserInputIsInt())
                {
                    try
                    {
                        int productIndex = int.Parse(userInput);
                        product = locationService.GetProductByIndex(productIndex);
                        Console.WriteLine($"\nAdding quantity to {product.Name}.");
                        Console.Write("Enter quantity being added: ");
                        int quantityAdded = int.Parse(Console.ReadLine());
                        locationService.AddToInvItem(productIndex, quantityAdded);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Failed to add quantity.");
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
            Product product = new Product();
            Console.WriteLine("\nAdding new product...");
            Console.Write("Enter product name: ");
            product.Name = Console.ReadLine();
            Console.WriteLine("\nAdding new product...");
            Console.Write("Enter product description: ");
            product.Description = Console.ReadLine();
            Console.WriteLine("\nAdding new product...");
            Console.Write("Enter product price: $");
            product.Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("\nAdding new product...");
            Console.Write("Enter initial quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            InvItem newInvItem = new InvItem(product, quantity);

            Console.WriteLine("\nConfirm new product (Y/N)?");
            newInvItem.Write();
            string confirm = Console.ReadLine();
            if (Regex.IsMatch(confirm, "y|Y"))
            {
                locationService.AddNewProductToInventory(newInvItem);
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