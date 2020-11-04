using System;
using StoreDB;
using StoreLib;
using System.Collections.Generic;
using StoreDB.Models;
using System.Text.RegularExpressions;
using Serilog;

namespace StoreUI
{
    /// <summary>
    /// The customer menu that list locations to shop at and includes the
    /// option to view customer orders.
    /// </summary>
    internal class CustomerMenu : Menu
    {
        protected ICustomerRepo repo;
        protected CustomerService service;

        public CustomerMenu(ICustomerRepo repo, Customer customer)
        {
            this.repo = repo;
            this.service = new CustomerService(repo, customer);
        }

        /// <summary>
        /// Runs the menu in console
        /// </summary>
        public override void Start()
        {
            Log.Debug("Started CustomerMenu instance");
            do
            {
                Console.WriteLine("\nSelect a store location or view orders.");
                List<Location> locations = service.GetLocations();
                foreach (Location loc in locations)
                {
                    Console.WriteLine($"[{locations.IndexOf(loc)}] {loc.Name}");
                }
                Console.WriteLine("[V] View Orders");
                Console.WriteLine("[X] Go back");
                userInput = Console.ReadLine();
                if (UserInputIsInt())
                {
                    int index = int.Parse(userInput);
                    if (index<locations.Count)
                    {
                        SelectLocation(locations[index]);
                    }
                }
                else if (Regex.IsMatch(userInput, "^v|V$"))
                {
                    ViewOrders();
                }
                else if (!UserInputIsX())
                {
                    Console.WriteLine("Invalid input.");
                }
            } while (!UserInputIsX());
        }

        protected void SelectLocation(Location location)
        {
            subMenu = new CustomerLocationMenu((ILocationRepo)repo, service.Customer, location);
            subMenu.Start();
        }

        protected void ViewOrders()
        {
            Console.WriteLine("\nViewing your orders.");
            service.WriteOrdersByDateDescend();
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
                        service.WriteOrdersByDateDescend();
                        break;
                    case "1":
                        Console.WriteLine("\nViewing your orders.");
                        service.WriteOrdersByDateAscend();
                        break;
                    case "2":
                        Console.WriteLine("\nViewing your orders.");
                        service.WriteOrdersByCostAscend();
                        break;
                    case "3":
                        Console.WriteLine("\nViewing your orders.");
                        service.WriteOrdersByCostDescend();
                        break;
                }
            } while (!UserInputIsX());
            userInput = "";
        }
    }
}