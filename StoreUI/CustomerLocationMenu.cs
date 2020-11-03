using System;
using StoreDB;
using StoreLib;
using StoreDB.Models;
using System.Collections.Generic;

namespace StoreUI
{
    internal class CustomerLocationMenu : Menu
    {
        private ILocationRepo repo;
        protected CustomerService customerService;
        protected LocationService locationService;
        protected CartService cartService;

        public CustomerLocationMenu(ILocationRepo repo, Customer customer, Location location)
        {
            this.repo = repo;
            this.customerService = new CustomerService((ICustomerRepo)repo, customer);
            this.locationService = new LocationService(repo, location);
            this.cartService = new CartService((ICartRepo)repo, customer, location);
        }

        public override void Start()
        {
            do
            {
                Console.WriteLine($"\nWelcome to our {locationService.Location.Name} location!");
                Console.WriteLine("[0] Shop products");
                Console.WriteLine("[1] Add product to cart");
                Console.WriteLine("[2] Go to cart");
                Console.WriteLine("[X] Back to previous menu");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        Console.WriteLine($"\nViewing products for {locationService.Location.Name} location.");
                        locationService.WriteInventory();
                        break;
                    case "1":
                        AddProductToCart();
                        break;
                    case "2":
                        subMenu = new CartMenu(cartService);
                        subMenu.Start();
                        break;
                }
            } while (!UserInputIsX());
        }

        private void AddProductToCart()
        {
            Console.WriteLine("\nEnter product number to add to cart, or enter X to go back.");
            List<InvItem> inventory = locationService.GetInventory();
            locationService.WriteInventory();
            do 
            {
                userInput = Console.ReadLine();
                if (UserInputIsInt() && int.Parse(userInput)<inventory.Count)
                {
                    InvItem item = inventory[int.Parse(userInput)];
                    AddProductQuantity(item.Product);
                }
                else if (!UserInputIsX())
                {
                    Console.WriteLine("Invalid input. Please enter an integer value.");
                }
            } while (!UserInputIsX());
            userInput = "";
        }

        private void AddProductQuantity(Product product)
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
                        cartService.AddToCart(new CartItem(product, quantity));
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