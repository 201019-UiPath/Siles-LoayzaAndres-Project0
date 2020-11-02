using System.Collections.Generic;
using StoreDB.Models;

namespace StoreDB
{
    public interface IShopRepo
    {
        /// <summary>
        /// Returns a List of the Locations held in the repository. Each
        /// Each Location is initialized without its inventory or orders.
        /// </summary>
        /// <returns></returns>
         List<Location> GetLocations();

         bool HasLocation(int index);

         IShopRepo SetCurrentCustomer(int index);

         ILocationRepo SetCurrentLocation(int index);

         List<Order> GetCustomerOrders();
    }
}