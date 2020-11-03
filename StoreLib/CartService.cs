using System;
using System.Collections.Generic;
using StoreDB;
using StoreDB.Models;

namespace StoreLib
{
    public class CartService
    {
        private ICartRepo repo;
        public Customer Customer {get; private set;}
        public Location Location {get; private set;}
        public Cart Cart {get; private set;}

        public CartService(ICartRepo repo, Customer customer, Location location)
        {
            this.repo = repo;
            this.Customer = customer;
            this.Location = location;
            this.Cart = repo.GetCart(Customer.Id, Location.Id);
        }

        public void AddToCart(CartItem item)
        {
            item.CartId = Cart.Id;
            repo.AddCartItem(item);
        }

        public void RemoveCartItem(CartItem cartItem)
        {
            repo.RemoveCartItem(cartItem);
        }

        public void EmptyCart()
        {
            repo.EmptyCart(Cart.Id);
        }

        public List<CartItem> GetCartItems()
        {
            return repo.GetCartItems(Cart.Id);
        }

        public void WriteCart()
        {
            List<CartItem> items = GetCartItems();
            Console.WriteLine($"{items.Count} products in your cart.");
            int i = 0;
            foreach(var item in items)
            {
                Console.Write($"[{i}] ");
                item.Write();
                i++;
            }
            Console.WriteLine($"Subtotal: ${Cart.Cost}");
        }

        public Order PlaceOrder()
        {
            Order order = new Order();
            order.LocationId = Location.Id;
            order.CustomerId = Customer.Id;
            order.LocationAddress = Location.Address;
            order.CustomerAddress = Customer.Address;
            order.DateTime = DateTime.Now;
            order.Items = new List<OrderItem>();
            foreach(CartItem c in GetCartItems())
            {
                order.Items.Add(new OrderItem(c.Product, c.Quantity));
            }
            order.Cost = Cart.Cost;

            repo.PlaceOrder(Location.Id, Cart.Id, order);
            
            return order;
        }
    }
}