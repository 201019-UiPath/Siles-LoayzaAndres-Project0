using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using StoreDB.Models;

namespace StoreDB
{
    /// <summary>
    /// Repository for accessing shop data from JSON files.
    /// </summary>
    public class FileRepo //: IShopRepo
    {
        const string testData = @"StoreDB\TestData\auto.JSON";

        /// <summary>
        /// Returns a list of all locations available
        /// </summary>
        /// <returns></returns>
        private async Task<List<Location>> GetLocationsFromFile()
        {
            //get Location objects from JSON
            List<Location> locations;
            using (FileStream fs = File.OpenRead(testData))
            {
                locations = await JsonSerializer.DeserializeAsync<List<Location>>(fs);
            }

            //convert List<Location> to List<ILocation>
            List<Location> result = new List<Location>(); 
            foreach (var loc in locations)
            {
                result.Add(loc);
            }

            return result;
        }

        public List<Location> GetLocations()
        {
            return GetLocationsFromFile().Result;
        }

        public async void WriteLocationsToFile(List<Location> locations)
        {
            using(FileStream fs = File.Create(@"StoreDB\TestData\auto.JSON"))
            {
                await JsonSerializer.SerializeAsync(fs, locations);
            }
        }

        public bool HasLocation(int index)
        {
            throw new System.NotImplementedException();
        }
    }
}
