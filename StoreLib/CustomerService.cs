using System;
using System.Collections.Generic;
using StoreDB;
using StoreDB.Models;

namespace StoreLib
{
    public class CustomerService
    {
        private ICustomerRepo repo;
        public CustomerService(ICustomerRepo repo)
        {
            this.repo = repo;
        }

        public List<Location> GetLocations()
        {
            return repo.GetLocations().Result;
        }

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