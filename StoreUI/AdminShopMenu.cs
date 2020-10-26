using System;

namespace StoreUI
{
    internal class AdminShopMenu : ShopMenu
    {
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

        protected override void readInput()
        {
            userInput = Console.ReadLine();
                foreach(var location in locations)
                {
                    if (userInput==locationIndex(location))
                    {
                        subMenu = new AdminLocationMenu(location);
                        subMenu.Start();
                        break;
                    }
                }
        }       
    }
}