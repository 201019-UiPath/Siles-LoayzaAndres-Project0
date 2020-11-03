using System.Collections.Generic;
using StoreDB;
using StoreDB.Models;

namespace StoreLib
{
    public class AdminService
    {
        IAdminRepo repo;

        public AdminService(IAdminRepo repo)
        {
            this.repo = repo;
        }

        public void AddLocation(Location location)
        {
            repo.AddLocation(location);
        }

        public List<Location> GetLocations()
        {
            return repo.GetLocations().Result;
        }

        public List<Order> GetOrders()
        {
            return repo.GetLocationOrders();
        }
    }
}