using System.Collections.Generic;
using StoreLib;
using System.Threading.Tasks;

namespace StoreDB
{
    public interface IShopRepo
    {
         Task<List<Location>> GetLocationsFromFile();

         List<Location> GetLocations();
    }
}