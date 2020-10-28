using StoreDB;
using System.Collections.Generic;

namespace StoreLib
{
    public class Shop
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
