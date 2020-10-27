using System;
using StoreLib;
using StoreDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreBL
{
    public class Shop : IShop
    {
        public List<Location> GetLocations()
        {
            IShopRepo repo = new ShopRepo();
            return repo.GetLocations();
        }

        public void CreateLocations()
        {
            ShopRepo repo = new ShopRepo();
            repo.CreateLocations();
        }
    }
}
