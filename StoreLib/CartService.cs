using System.Collections.Generic;
using StoreDB;
using StoreDB.Models;

namespace StoreLib
{
    public class CartService
    {
        private ILocationRepo repo;
        private ICustomerRepo customerRepo;

        public CartService(ILocationRepo repo)
        {
            this.repo = repo;
            this.customerRepo = (ICustomerRepo)repo;
        }

        public void AddToCart(CartItem item)
        {
            item.CartId = repo.GetCart().Result.Id;
            repo.AddCartItem(item);
        }

        public void RemoveFromCart(int index)
        {
            this.repo.RemoveFromCart(index);
        }

        public void EmptyCart()
        {
            this.repo.EmptyCart();
        }

        public void QuickWriteCart()
        {
            repo.GetCart().Result.QuickWrite();
        }

        public void WriteCart()
        {
            repo.GetCart().Result.Write();
        }

        public Order PlaceOrder()
        {
            Location loc = repo.GetLocation();
            Customer custom = customerRepo.GetCustomer();
            Cart cart = repo.GetCart().Result;
            Order order = new Order();
            order.LocationId = loc.Id;
            order.CustomerId = custom.Id;
            order.LocationAddress = loc.Address;
            order.CustomerAddress = custom.Address;
            order.Items = new List<OrderItem>();
            foreach(CartItem c in cart.Items)
            {
                OrderItem o = new OrderItem();
                o.Product = c.Product;
                o.Quantity = c.Quantity;
                order.Items.Add(o);
            }
            order.Cost = cart.Cost;

            repo.PlaceOrder(order);
            
            return order;
        }
    }
}