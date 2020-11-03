using System;
using StoreDB;
using StoreLib;
using System.Collections.Generic;
using StoreDB.Models;
using System.Text.RegularExpressions;

namespace StoreUI
{
    /// <summary>
    /// The shop menu that list locations to shop at
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
            service.WriteOrders();
        }
    }
}