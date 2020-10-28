using System;
using StoreDB;
using StoreLib;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace StoreUI
{
    internal class LocationMenu : Menu
    {
        protected Location location;
        protected LocationService locationService;
        protected CartService cartService;

        public LocationMenu(Location location)
        {
            this.location = location;
            this.locationService = new LocationService(location);
            this.cartService = new CartService();
        }

        public override void Start()
        {
            do
            {
                Console.WriteLine($"\nWelcome to our {location.Name} location!");
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
                        ViewCart();
                        break;
                }
            } while (!UserInputIsX());
        }

        protected void ViewProducts()
        {
            do 
            {
                Console.WriteLine($"\nViewing products for {location.Name} location.");
                Console.WriteLine("Enter product number to add to cart, or enter X to go back.");
                locationService.WriteInventory();
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

        private void ViewCart()
        {
            do
            {
                Console.WriteLine("\nViewing cart.");
                cartService.WriteCart();
                Console.WriteLine("[0] Remove product");
                Console.WriteLine("[1] Empty cart");
                Console.WriteLine("[2] Checkout order");
                Console.WriteLine("[X] Return to previous menu");
                userInput = Console.ReadLine();
            } while(!UserInputIsX());
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