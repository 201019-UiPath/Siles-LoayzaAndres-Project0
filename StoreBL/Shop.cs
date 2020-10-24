using System;
using StoreLib;
using StoreDB;
using System.Collections.Generic;

namespace StoreBL
{
    public class Shop : IShop
    {
        public List<ILocation> GetLocations()
        {
            IRepo repo = new ShopRepo();
            return repo.GetLocations();
        }
    }
}
