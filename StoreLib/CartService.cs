using System;
using System.Collections.Generic;
using StoreDB;
using StoreDB.Models;

namespace StoreLib
{
    public class CartService
    {
        private ILocationRepo repo;
        private ICustomerRepo customerRepo;
        private ICartRepo cartRepo;

        public CartService(ILocationRepo repo)
        {
            this.repo = repo;
            this.customerRepo = (ICustomerRepo)repo;
            this.cartRepo = (ICartRepo)repo;
        }

        public void AddToCart(CartItem item)
        {
            item.CartId = cartRepo.GetCart().Id;
            cartRepo.AddCartItem(item);
        }

        public void RemoveProductFromCart(int productId)
        {
            cartRepo.RemoveProductFromCart(productId);
        }

        public void EmptyCart()
        {
            cartRepo.EmptyCart();
        }

        public Cart GetCart()
        {
            return cartRepo.GetCart();
        }

        public void WriteCart()
        {
            cartRepo.GetCart().Write();
        }

        public Order PlaceOrder()
        {
            Location loc = repo.GetLocation();
            Customer custom = customerRepo.GetCustomer();
            Cart cart = cartRepo.GetCart();
            Order order = new Order();
            order.LocationId = loc.Id;
            order.CustomerId = custom.Id;
            order.LocationAddress = loc.Address;
            order.CustomerAddress = custom.Address;
            order.DateTime = DateTime.Now;
            order.Items = new List<OrderItem>();
            foreach(CartItem c in cart.Items)
            {
                order.Items.Add(new OrderItem(c.Product, c.Quantity));
            }
            order.Cost = cart.Cost;

            cartRepo.PlaceOrder(order);
            
            return order;
        }
    }
}