using System.Collections.Generic;
using StoreLib;

namespace StoreBL
{
    public interface IShop
    {
         List<Location> GetLocations();
    }
}