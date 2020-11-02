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
                Console.WriteLine("\nWelcome to the shop!");
                Console.WriteLine("[0] Shop");
                Console.WriteLine("[1] View Orders");
                Console.WriteLine("[X] Go back");
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
            List<Location> locations = service.GetLocations();
            foreach (Location loc in locations)
            {
                Console.WriteLine($"[{locations.IndexOf(loc)}] {loc.Name}");
            }
            Console.WriteLine("[x] Go back.");
            userInput = Console.ReadLine();
            if (UserInputIsInt())
            {
                int index = int.Parse(userInput);
                if (index<locations.Count)
                {
                    subMenu = new LocationMenu(repo.SetCurrentLocation(locations[index]));
                    subMenu.Start();
                }
                
            }
            else if (!UserInputIsX())
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
            userInput = "";
        }

        protected void ViewOrders()
        {
            Console.WriteLine("Viewing your orders.");
            service.WriteOrders();
        }
    }
}