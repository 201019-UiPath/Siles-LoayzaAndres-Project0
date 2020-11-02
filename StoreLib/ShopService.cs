﻿using StoreDB;
using System.Collections.Generic;
using StoreDB.Models;

namespace StoreLib
{
    public class ShopService
    {
        protected IShopRepo repo;

        public ShopService(IShopRepo repo)
        {
            this.repo = repo;
        }

        public void AddLocation(Location location)
        {
            repo.AddLocation(location);
        }

        public List<Location> GetLocations()
        {
            return repo.GetLocations().Result;
        }

        /*
        public bool HasLocation(int index)
        {
            return repo.HasLocation(index);
        }
        */
    }
}