using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using StoreDB;
using StoreDB.Models;
using StoreLib;
using Serilog;

namespace StoreUI
{
    internal class AdminMenu : Menu
    {
        protected IAdminRepo repo;
        protected AdminService service;
        private List<Location> locations;

        public AdminMenu(IAdminRepo repo)
        {
            this.repo = repo;
            this.service = new AdminService(repo);
        }

        public override void Start()
        {
            Log.Debug("Started AdminMenu instance");
            do
            {
                Console.WriteLine("\nWelcome to the admin store selection!");
                Console.WriteLine("Please select a store location.");
                locations = service.GetLocations();
                foreach (Location loc in locations)
                {
                    Console.WriteLine($"[{locations.IndexOf(loc)}] {loc.Name}");
                }
                Console.WriteLine("[A] Add a location");
                Console.WriteLine("[X] Back to Main Menu");
                readInput();
            } while (!UserInputIsX());
        } 

        protected void readInput()
        {
            userInput = Console.ReadLine();
            if (UserInputIsInt())
            {
                int index = int.Parse(userInput);
                if (index<locations.Count)
                {
                    subMenu = new AdminLocationMenu((ILocationRepo)repo, service, locations[index]);
                    subMenu.Start();
                }
                
            }
            else if (Regex.IsMatch(userInput, "^a|A$"))
            {
                Location newLoc = new Location();
                newLoc.Address = new Address();
                Console.Write("Enter location name: ");
                newLoc.Name = Console.ReadLine();
                Console.Write("Enter street address: ");
                newLoc.Address.Street = Console.ReadLine();
                Console.Write("Enter city: ");
                newLoc.Address.City = Console.ReadLine();
                Console.Write("Enter state: ");
                newLoc.Address.State = Console.ReadLine();
                Console.Write("Enter zip: ");
                newLoc.Address.Zip = int.Parse(Console.ReadLine());
                Console.Write("Enter country: ");
                newLoc.Address.Country = Console.ReadLine();
                this.service.AddLocation(newLoc);
                Console.WriteLine($"New location {newLoc.Name} added!");
                Log.Information($"Added {@newLoc} in AdminMenu");
            }
            else if (!UserInputIsX())
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
        }       
    }
}