using System;
using StoreDB;
using StoreLib;
using StoreDB.Models;

namespace StoreUI
{
    internal class LocationMenu : Menu
    {
        private ILocationRepo repo;
        protected LocationService locationService;
        protected CartService cartService;

        public LocationMenu(ILocationRepo repo)
        {
            this.repo = repo;
            this.locationService = new LocationService(repo);
            this.cartService = new CartService(repo);
        }

        public override void Start()
        {
            do
            {
                Console.WriteLine($"\nWelcome to our {locationService.GetName()} location!");
                Console.WriteLine("[0] View products");
                Console.WriteLine("[1] View cart");
                Console.WriteLine("[X] Back to previous menu");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        ViewProducts();
                        break;
                    case "1":
                        subMenu = new CartMenu(repo);
                        subMenu.Start();
                        break;
                }
            } while (!UserInputIsX());
        }

        private void ViewProducts()
        {
            do 
            {
                Console.WriteLine($"\nViewing products for {locationService.GetName()} location.");
                locationService.WriteInventory();
                Console.WriteLine("\nEnter product number to add to cart, or enter X to go back.");
                userInput = Console.ReadLine();
                if (UserInputIsInt())
                {
                    int index = int.Parse(userInput);
                    Product product = locationService.GetProductByIndex(index);
                    AddProductToCart(product);
                }
                else if (!UserInputIsX())
                {
                    Console.WriteLine("Invalid input. Please enter an integer value.");
                }
            } while (!UserInputIsX());
            userInput = "";
        }

        private void AddProductToCart(Product product)
        {
            do
            {
                Console.WriteLine($"\nAdding \"{product.Name}\" to cart. Enter X to cancel.");
                Console.Write($"Enter quantity for \"{product.Name}\": ");
                userInput = Console.ReadLine();
                int quantity = 1;
                if (UserInputIsInt())
                {
                    quantity = int.Parse(userInput);
                    try
                    {
                        cartService.AddToCart(new Stock(product, quantity));
                        Console.WriteLine($"Added {quantity} of {product.Name} to cart.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Failed to add {product.Name} to cart. {e.Message}");
                    }
                    break;
                }
                else if (!UserInputIsX())
                {
                    Console.WriteLine("Invalid input. Please enter integer value or X to cancel.");
                }
            } while (!UserInputIsX());
            userInput = "";
        }
    }
}