using System;
using System.Collections.Generic;
using StoreDB;
using StoreDB.Models;

namespace StoreLib
{
    public class CustomerService : ShopService
    {
        public CustomerService(IShopRepo repo) : base(repo) {}

        public void WriteOrders()
        {
            List<Order> orders = this.repo.GetCustomerOrders();
            foreach(Order o in orders)
            {
                o.Write();
            }
        }
    }
}