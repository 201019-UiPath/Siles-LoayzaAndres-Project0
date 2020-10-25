using System.Collections.Generic;
using StoreLib;
using System.Threading.Tasks;

namespace StoreDB
{
    public interface IShopRepo
    {
         Task<List<ILocation>> GetLocationsFromFile();

         List<ILocation> GetLocations();
    }
}