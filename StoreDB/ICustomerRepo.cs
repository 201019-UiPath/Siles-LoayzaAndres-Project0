using System.Collections.Generic;
using System.Threading.Tasks;
using StoreDB.Models;

namespace StoreDB
{
    public interface ICustomerRepo : IStoreRepo
    {
        Customer GetCustomer();
        
        List<Order> GetCustomerOrders();

        ICustomerRepo SetCurrentCustomer(int index);

    }
}