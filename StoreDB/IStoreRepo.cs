using System.Collections.Generic;
using System.Threading.Tasks;
using StoreDB.Models;

namespace StoreDB
{
    public interface IStoreRepo
    {
         Task<List<Location>> GetLocations();

         ILocationRepo SetCurrentLocation(Location location);
    }
}