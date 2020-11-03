using System;
using System.Collections.Generic;
using StoreDB;
using StoreDB.Models;

namespace StoreLib
{
    public class CustomerService
    {
        private ICustomerRepo repo;
        public Customer Customer {get; private set;}

        public CustomerService(ICustomerRepo repo, Customer customer)
        {
            this.repo = repo;
            this.Customer = customer;
        }

        public List<Location> GetLocations()
        {
            return repo.GetLocations().Result;
        }

        public void WriteOrders()
        {
            List<Order> orders = this.repo.GetCustomerOrders(Customer.Id);
            foreach(Order o in orders)
            {
                o.Write();
            }
        }
    }
}