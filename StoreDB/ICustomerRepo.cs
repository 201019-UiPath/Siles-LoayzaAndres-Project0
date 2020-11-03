using System.Collections.Generic;
using System.Threading.Tasks;
using StoreDB.Models;

namespace StoreDB
{
    public interface ICustomerRepo : IStoreRepo
    {
        Customer GetDefaultCustomer();
        
        List<Order> GetCustomerOrders(int customerId);
    }
}