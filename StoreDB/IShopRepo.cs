using System.Collections.Generic;
using StoreDB;
using System.Threading.Tasks;

namespace StoreDB
{
    public interface IShopRepo
    {
         Task<List<Location>> GetLocationsFromFile();

         List<Location> GetLocations();
    }
}