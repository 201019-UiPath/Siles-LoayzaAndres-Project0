using System.Collections.Generic;
using System.Threading.Tasks;
using StoreDB.Models;

namespace StoreDB
{
    public interface IAdminRepo : IStoreRepo
    {
        void AddLocation(Location location);

        List<Order> GetLocationOrders();
    }
}