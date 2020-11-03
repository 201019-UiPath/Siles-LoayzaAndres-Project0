using System;
using StoreDB;
using System.Text.RegularExpressions;
using StoreDB.Models;
using System.Collections.Generic;
using StoreLib;

namespace StoreUI
{
    internal class CartMenu : Menu
    {
        CartService cartService;
        
        public CartMenu(CartService cartService)
        {
            this.cartService = cartService;
        }

        public override void Start()
        {
            do
            {
                Console.WriteLine("\nWelcome to your cart.");
                Console.WriteLine("[0] View products in cart");
                Console.WriteLine("[1] Remove product");
                Console.WriteLine("[2] Empty cart");
                Console.WriteLine("[3] Checkout order");
                Console.WriteLine("[X] Return to previous menu");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        Console.Write("\n");
                        cartService.WriteCart();
                        break;
                    case "1":
                        RemoveProduct();
                        break;
                    case "2":
                        EmptyCart();
                        break;
                    case "3":
                        Checkout();
                        break;
                }
            } while(!UserInputIsX());
        }

        private void RemoveProduct()
        {
            Console.WriteLine("\nEnter product number to remove, or X to go back: ");
            List<CartItem> items = cartService.GetCartItems();
            cartService.WriteCart();
            userInput = Console.ReadLine();
            if (!UserInputIsX() && UserInputIsInt())
            {
                try
                {
                    cartService.RemoveCartItem(items[int.Parse(userInput)]);
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
            try
            {
                Order order = cartService.PlaceOrder();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to checkout cart. {e.Message}");
            }
        }
    }
}