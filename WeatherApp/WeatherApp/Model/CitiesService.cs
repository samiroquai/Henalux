using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace WeatherApp.Model
{
    public class CitiesService
    {
        const char SEPARATOR = ';';
        const string SETTING_KEY = "Cities.json";
        public async Task<IEnumerable<City>> LoadCitiesAsync()
        {
            var folder = Folder();
            var files = await folder.GetFilesAsync();
            if (!files.Any(f => f.Name == SETTING_KEY))
            {
                var file = await folder.CreateFileAsync(SETTING_KEY);
                var cities = new City[]
                {
                    new City()
                    {
                         Name="Namur",
                         Country="Belgique"
                    }
                };
                await FileIO.WriteTextAsync(file, JsonConvert.SerializeObject(cities));
                return cities;
            }
            else
            {
                //await files.First(f => f.Name == SETTING_KEY).DeleteAsync(StorageDeleteOption.PermanentDelete);
                var file = files.First(f => f.Name == SETTING_KEY);
                var json = await FileIO.ReadTextAsync(file);
                return JsonConvert.DeserializeObject<City[]>(json);
                //return new City[0];
            }
        }

        private static Windows.Storage.StorageFolder Folder()
        {
            var applicationData = Windows.Storage.ApplicationData.Current;
            var localSettings = applicationData.RoamingFolder;
            return localSettings;
        }

       
    }
}
