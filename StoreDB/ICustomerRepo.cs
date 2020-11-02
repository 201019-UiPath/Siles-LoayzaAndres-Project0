using StoreDB.Models;

namespace StoreDB
{
    public interface ICustomerRepo
    {
         Customer GetCustomer();
         void AddOrderToCustomer(Order order);
    }
}