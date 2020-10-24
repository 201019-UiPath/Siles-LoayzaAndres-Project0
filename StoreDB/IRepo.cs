using System.Collections.Generic;
using StoreLib;

namespace StoreDB
{
    public interface IRepo
    {
         List<ILocation> GetLocations();
    }
}