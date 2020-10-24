using System;

namespace StoreUI
{
    internal class MainMenu : Menu
    {
        public override void Start()
        {

            do
            {
                Console.WriteLine("\nWelcome!");
                Console.WriteLine("What would you like to do today?");
                Console.WriteLine("[0] Shop");
                Console.WriteLine("[X] Quit");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        subMenu = new ShopMenu();
                        subMenu.Start();
                        break;
                }
            } while (!UserInputIsX());
        }

    }
}