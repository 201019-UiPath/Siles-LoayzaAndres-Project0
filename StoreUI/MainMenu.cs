using System;
using StoreDB;
using StoreDB.Models;

namespace StoreUI
{
    internal class MainMenu : Menu
    {
        private IRepo repo;

        public MainMenu()
        {
            this.repo = new DBRepo(new StoreContext());
        }

        public override void Start()
        {

            do
            {
                Console.WriteLine("\nWelcome!");
                Console.WriteLine("Are you a customer or an admin?");
                Console.WriteLine("[0] Customer");
                Console.WriteLine("[1] Admin");
                Console.WriteLine("[X] Quit");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        StartCustomerMenu();
                        break;
                    case "1":
                        StartAdminMenu();
                        break;
                }
            } while (!UserInputIsX());
        }

        private void StartCustomerMenu()
        {
            repo.SetCurrentCustomer(1); //TODO: REMOVE HARD CODE
            subMenu = new ShopMenu(repo);
            subMenu.Start();
        }

        private void StartAdminMenu()
        {
            subMenu = new AdminShopMenu(repo);
            subMenu.Start();
        }

    }
}