using System.Collections.Generic;
using StoreDB;

namespace StoreLib
{
    public interface IShop
    {
         List<Location> GetLocations();
    }
}