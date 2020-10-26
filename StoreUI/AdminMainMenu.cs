using System;

namespace StoreUI
{
    internal class AdminMainMenu : MainMenu
    {
        public override void Start()
        {
            do
            {
                Console.WriteLine("\nWelcome to the admin menu!");
                Console.WriteLine("What would you like to do today?");
                Console.WriteLine("[0] Add Inventory");
                Console.WriteLine("[X] Quit");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        subMenu = new AdminShopMenu();
                        subMenu.Start();
                        break;
                }
            } while (!UserInputIsX());
        }
    }
}