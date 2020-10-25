using System;
using StoreBL;
using StoreLib;
using System.Collections.Generic;

namespace StoreUI
{
    /// <summary>
    /// The shop menu that list locations to shop at
    /// </summary>
    internal class ShopMenu : Menu
    {
        protected IShop shop;
        protected List<ILocation> locations;

        /// <summary>
        /// Runs the menu in console
        /// </summary>
        public override void Start()
        {
            do
            {
                Console.WriteLine("Welcome to the shop!");
                Console.WriteLine("\nPlease select a store location.");
                writeLocations();
                Console.WriteLine("[X] Back to Main Menu");
                readInput();
            } while (!UserInputIsX());
        }

        public override void StartAdmin()
        {
            do
            {
                Console.WriteLine("\nWelcome to the admin store selection!");
                Console.WriteLine("Please select a store location.");
                writeLocations();
                Console.WriteLine("[X] Back to Main Menu");
                readAdminInput();
            } while (!UserInputIsX());
        }

        /// <summary>
        /// Outputs the list of locations into the console, each preceded by 
        /// its index.
        /// </summary>
        protected void writeLocations()
        {
            this.shop = new Shop();
            locations = shop.GetLocations();
            foreach (var location in locations)
            {
                Console.WriteLine($"[{locationIndex(location)}] {location.Name}");
            }
        }

        /// <summary>
        /// Reads a line of console input and iterates through List of
        /// locations to find user choice based on index. If location is found,
        /// creates a new LocationMenu, assigns subMenu, and calls Start().
        /// Else, returns void.
        /// </summary>
        protected void readInput()
        {
            userInput = Console.ReadLine();
                foreach(var location in locations)
                {
                    if (userInput==locationIndex(location))
                    {
                        subMenu = new LocationMenu(location);
                        subMenu.Start();
                        break;
                    }
                }
        }

        protected void readAdminInput()
        {
            userInput = Console.ReadLine();
                foreach(var location in locations)
                {
                    if (userInput==locationIndex(location))
                    {
                        subMenu = new LocationMenu(location);
                        subMenu.StartAdmin();
                        break;
                    }
                }
        }

        /// <summary>
        /// Returns the index of the given location in the locations List as a
        /// string.
        /// </summary>
        /// <param name="location"></param>
        /// <returns>index of the given location as a string</returns>
        protected string locationIndex(ILocation location)
        {
            return locations.IndexOf(location).ToString();
        }
    }
}