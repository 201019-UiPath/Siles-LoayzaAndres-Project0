using System.Collections.Generic;
using StoreLib;

namespace StoreBL
{
    public interface IShop
    {
         List<ILocation> GetLocations();
    }
}