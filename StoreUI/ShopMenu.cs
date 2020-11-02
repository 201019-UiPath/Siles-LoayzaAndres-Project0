using System;
using StoreDB;
using StoreLib;
using System.Collections.Generic;
using StoreDB.Models;

namespace StoreUI
{
    /// <summary>
    /// The shop menu that list locations to shop at
    /// </summary>
    internal class ShopMenu : Menu
    {
        protected IShopRepo repo;
        protected CustomerService service;

        public ShopMenu(IShopRepo repo)
        {
            this.repo = repo;
            this.service = new CustomerService(repo);
        }

        /// <summary>
        /// Runs the menu in console
        /// </summary>
        public override void Start()
        {
            do
            {
                Console.WriteLine("Welcome to the shop!");
                Console.WriteLine("[0] Shop");
                Console.WriteLine("[1] View Orders");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        SelectLocation();
                        break;
                    case "1":
                        ViewOrders();
                        break;
                }
            } while (!UserInputIsX());
        }

        protected void SelectLocation()
        {
            Console.WriteLine("\nPlease select a store location.");
            writeLocations();
            userInput = Console.ReadLine();
            if (UserInputIsInt())
            {
                int index = int.Parse(userInput);
                if (service.HasLocation(index))
                {
                    subMenu = new LocationMenu(repo.SetCurrentLocation(index));
                    subMenu.Start();
                }
                
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
        }

        /// <summary>
        /// Outputs the list of locations into the console, each preceded by 
        /// its index.
        /// </summary>
        protected void writeLocations()
        {
            List<Location> locations = service.GetLocations();
            foreach (Location loc in locations)
            {
                Console.WriteLine($"[{locations.IndexOf(loc)}] {loc.Name}");
            }
        }

        protected void ViewOrders()
        {
            Console.WriteLine("Viewing your orders.");
            service.WriteOrders();
        }
    }
}