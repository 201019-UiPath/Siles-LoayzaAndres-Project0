using System;
using StoreLib;
using StoreBL;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace StoreUI
{
    internal class LocationMenu : Menu
    {
        protected Location location;
        protected ILocationBL locationBL;
        protected string[] inventoryKeys;

        public LocationMenu(Location location)
        {
            this.location = location;
            this.locationBL = new LocationBL(location);
            this.inventoryKeys = locationBL.GetAllProductKeys();
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
                locationBL.WriteInventory();
                userInput = Console.ReadLine();
                if (UserInputIsInt() && int.Parse(userInput)<locationBL.GetInventoryCount())
                {
                    this.AddProductToCart( inventoryKeys[int.Parse(userInput)] );
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
                locationBL.WriteCart();
                Console.WriteLine("[0] Remove product");
                Console.WriteLine("[1] Empty cart");
                Console.WriteLine("[2] Checkout order");
                Console.WriteLine("[X] Return to previous menu");
                userInput = Console.ReadLine();
            } while(!UserInputIsX());
            userInput = "";
        }

        private void AddProductToCart(string productKey)
        {
            do
            {
                Console.WriteLine($"\nAdding \"{productKey}\" to cart. Enter X to cancel.");
                Console.Write($"Enter amount for \"{productKey}\": ");
                userInput = Console.ReadLine();
                int amount = 1;
                if (UserInputIsInt())
                {
                    amount = int.Parse(userInput);
                    try
                    {
                        locationBL.AddProductToCart(productKey, amount);
                        Console.WriteLine($"Added {amount} of {productKey} to cart.");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"Failed to add {productKey} to cart. {e.Message}");
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