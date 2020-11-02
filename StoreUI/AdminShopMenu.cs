using System;
using System.Collections.Generic;
using StoreDB;
using StoreDB.Models;
using StoreLib;

namespace StoreUI
{
    internal class AdminShopMenu : Menu
    {
        protected IShopRepo repo;
        protected ShopService shopService;

        public AdminShopMenu(IShopRepo repo)
        {
            this.repo = repo;
            this.shopService = new ShopService(repo);
        }

        public override void Start()
        {
            do
            {
                Console.WriteLine("\nWelcome to the admin store selection!");
                Console.WriteLine("Please select a store location.");
                writeLocations();
                Console.WriteLine("[X] Back to Main Menu");
                readInput();
            } while (!UserInputIsX());
        } 

        /// <summary>
        /// Outputs the list of locations into the console, each preceded by 
        /// its index.
        /// </summary>
        protected void writeLocations()
        {
            List<Location> locations = shopService.GetLocations();
            foreach (Location loc in locations)
            {
                Console.WriteLine($"[{locations.IndexOf(loc)}] {loc.Name}");
            }
        }

        protected void readInput()
        {
            userInput = Console.ReadLine();
            if (UserInputIsInt())
            {
                int index = int.Parse(userInput);
                if (shopService.HasLocation(index))
                {
                    subMenu = new AdminLocationMenu(repo.SetCurrentLocation(index));
                    subMenu.Start();
                }
                
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
        }       
    }
}