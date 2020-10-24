using System;
using StoreLib;
using System.Collections.Generic;

namespace StoreDB
{
    /// <summary>
    /// Repository for accessing shop data
    /// </summary>
    public class ShopRepo : IRepo
    {
        /// <summary>
        /// Returns a list of all locations available
        /// </summary>
        /// <returns></returns>
        public List<ILocation> GetLocations()
        {
            //dummy data
            List<ILocation> locations = new List<ILocation>();
            locations.Add(new Location("Washington, DC"));
            locations.Add(new Location("Sterling, VA"));
            locations.Add(new Location("Frederick, MD"));
            return locations;
        }
    }
}
