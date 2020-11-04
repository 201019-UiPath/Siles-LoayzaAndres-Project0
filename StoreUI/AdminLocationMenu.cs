using System;
using StoreDB;
using System.Text.RegularExpressions;
using StoreDB.Models;
using StoreLib;
using System.Collections.Generic;
using Serilog;

namespace StoreUI
{
    internal class AdminLocationMenu : Menu
    {
        AdminService adminService;
        LocationService locationService;

        public AdminLocationMenu(ILocationRepo repo, AdminService adminService, Location location) 
        {
            this.adminService = adminService;
            this.locationService = new LocationService(repo, location);
        }
        
        public override void Start()
        {
            Log.Debug("Started AdminLocationMenu instance");
            do
            {
                Console.WriteLine($"\nWelcome to our {locationService.Location.Name} location, admin!");
                Console.WriteLine("[0] View inventory");
                Console.WriteLine("[1] Add quantity");
                Console.WriteLine("[2] Add new product");
                Console.WriteLine("[3] View orders");
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
                    case "3":
                        ViewOrders();
                        break;
                }
            } while (!UserInputIsX());
        }

        protected void AddInvItem()
        {
            Console.WriteLine("\nSelect a product to add quantity. Enter X to go back.");
            List<InvItem> inventory = locationService.GetInventory();
            locationService.WriteInventory();
            do 
            {
                userInput = Console.ReadLine();
                if(UserInputIsInt() && int.Parse(userInput)<inventory.Count)
                {
                    InvItem item = inventory[int.Parse(userInput)];
                    try
                    {
                        Console.WriteLine($"\nAdding quantity to {item.Product.Name}.");
                        Console.Write("Enter quantity being added: ");
                        int quantityAdded = int.Parse(Console.ReadLine());
                        locationService.AddToInvItem(item.ProductId, quantityAdded);
                        Log.Information($"Added {@item} to {@locationService.Location} in AdminLocationMenu");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Failed to add quantity.");
                        Log.Error($"Failed to add {@item} to {@locationService.Location} in AdminLocationMenu. {e.Message}");
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
                Log.Information($"Added {@newInvItem} to {@locationService.Location} in AdminLocationMenu");
            }
            else
            {
                Console.WriteLine("New product cancelled. Press any key to go back.");
                Console.Read();
            }
            userInput = "";
        }

        protected void ViewOrders()
        {
            Console.WriteLine($"Viewing orders.");
            locationService.WriteOrdersByDateDescend();
            do 
            {
                Console.WriteLine("\n[0] Sort by most recent");
                Console.WriteLine("[1] Sort by oldest");
                Console.WriteLine("[2] Sort by least expensive");
                Console.WriteLine("[3] Sort by most expensive");
                Console.WriteLine("[X] Return to previous menu");
                userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "0":
                        Console.WriteLine("\nViewing your orders.");
                        locationService.WriteOrdersByDateDescend();
                        break;
                    case "1":
                        Console.WriteLine("\nViewing your orders.");
                        locationService.WriteOrdersByDateAscend();
                        break;
                    case "2":
                        Console.WriteLine("\nViewing your orders.");
                        locationService.WriteOrdersByCostAscend();
                        break;
                    case "3":
                        Console.WriteLine("\nViewing your orders.");
                        locationService.WriteOrdersByCostDescend();
                        break;
                }
            } while (!UserInputIsX());
            userInput = "";
        }
    }
}