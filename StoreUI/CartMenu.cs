using System;
using StoreDB;
using System.Text.RegularExpressions;
using StoreDB.Models;

namespace StoreUI
{
    internal class CartMenu : LocationMenu
    {
        public CartMenu(ILocationRepo repo) : base(repo) {}
        public override void Start()
        {
            do
            {
                Console.WriteLine("\nViewing cart.");
                cartService.QuickWriteCart();
                Console.WriteLine("[0] Remove product");
                Console.WriteLine("[1] Empty cart");
                Console.WriteLine("[2] Checkout order");
                Console.WriteLine("[X] Return to previous menu");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        RemoveProduct();
                        break;
                    case "1":
                        EmptyCart();
                        break;
                    case "2":
                        Checkout();
                        break;
                }
            } while(!UserInputIsX());
        }

        private void RemoveProduct()
        {
            Console.Write("Enter product number to remove, or X to go back: ");
            cartService.WriteCart();
            userInput = Console.ReadLine();
            if (!UserInputIsX() && UserInputIsInt())
            {
                try
                {
                    cartService.RemoveFromCart(int.Parse(userInput));
                    Console.WriteLine("Removed product from cart.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to remove product from cart. {e.Message}");
                }   
            }
        }

        private void EmptyCart()
        {
            Console.WriteLine("Warning! This action will remove all products from your cart.");
            Console.WriteLine("Proceed? (Y/N): ");
            userInput = Console.ReadLine();
            if (Regex.IsMatch(userInput, "^y|Y$"))
            {
                cartService.EmptyCart();
                Console.WriteLine("Action confirmed. Emptied cart.");
            }
            else
            {
                Console.WriteLine("Action cancelled. Did not empty cart.");
            }
        }

        private void Checkout()
        {
            Console.WriteLine("Starting checkout. Enter X to cancel any time.");
            Order order = cartService.PlaceOrder();
        }
    }
}