using System.Collections.Generic;
using System.Threading.Tasks;
using StoreDB.Models;

namespace StoreDB
{
    public interface IShopRepo
    {
        void AddLocation(Location location);

        /// <summary>
        /// Returns a List of the Locations held in the repository. Each
        /// Each Location is initialized without its inventory or orders.
        /// </summary>
        /// <returns></returns>
         Task<List<Location>> GetLocations();

         //bool HasLocation(int index);

         IShopRepo SetCurrentCustomer(int index);

         ILocationRepo SetCurrentLocation(Location location);

         List<Order> GetCustomerOrders();
    }
}