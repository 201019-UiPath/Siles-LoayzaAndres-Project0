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

        public void AddToCart(Stock stock)
        {
            repo.AddToCart(stock);
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
            repo.GetCart().QuickWrite();
        }

        public void WriteCart()
        {
            repo.GetCart().Write();
        }

        public Order PlaceOrder()
        {
            Location loc = repo.GetLocation();
            Customer custom = customerRepo.GetCustomer();
            Cart cart = repo.GetCart();
            Order order = new Order(loc.Id, custom.Id, loc.Address, custom.Address, cart.Products, cart.Cost);
            foreach(Stock stock in cart.Products)
            {
                repo.RemoveInventory(stock);
            }
            repo.EmptyCart();
            repo.AddOrderToLocation(order);
            customerRepo.AddOrderToCustomer(order);
            return order;
        }
    }
}