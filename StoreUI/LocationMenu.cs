using System;
using StoreLib;
using StoreBL;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace StoreUI
{
    internal class LocationMenu : Menu
    {
        protected ILocation location;
        protected ILocationBL locationBL;
        protected string[] inventoryKeys;

        public LocationMenu(ILocation location)
        {
            this.location = location;
            this.locationBL = new LocationBL(location);
            this.inventoryKeys = locationBL.GetAllItemKeys();
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
                Console.WriteLine($"Viewing products for {location.Name} location!");
                Console.WriteLine("\nEnter product number to add to cart, or enter X to go back.");
                locationBL.WriteInventory();
                userInput = Console.ReadLine();
                if (UserInputIsInt() && int.Parse(userInput)<locationBL.GetInventoryCount())
                {
                    this.AddItemToCart( inventoryKeys[int.Parse(userInput)] );
                }
                else
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
                Console.WriteLine("Viewing cart.");
                locationBL.WriteCart();
                Console.WriteLine("[0] Remove item");
                Console.WriteLine("[1] Empty cart");
                Console.WriteLine("[2] Checkout order");
                Console.WriteLine("[X] Return to previous menu");
                userInput = Console.ReadLine();
            } while(!UserInputIsX());
            userInput = "";
        }

        private void AddItemToCart(string itemKey)
        {
            do
            {
                Console.WriteLine($"\nAdding \"{itemKey}\" to cart. Enter X to cancel.");
                Console.Write($"Enter amount for \"{itemKey}\": ");
                userInput = Console.ReadLine();
                int amount = 1;
                if (UserInputIsInt())
                {
                    amount = int.Parse(userInput);
                    try
                    {
                        locationBL.AddItemToCart(itemKey, amount);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"Failed to add {itemKey} to cart. {e.Message}");
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