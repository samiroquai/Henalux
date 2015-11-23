using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class WeatherService : IWeatherService
    {
        public async Task<WeatherForecast> GetCurrentWeatherByCityAsync(City city)
        {
            return GetFakeForecast().First();
        }


        public async Task<IEnumerable<WeatherForecast>> GetForecastByCityAsync(City city)
        {
            var fakeForecast = GetFakeForecast();
            int numberOfForecastsAlreadyLoopedThrough = 0;
            foreach (var forecast in fakeForecast)
            {
                forecast.City = city;
                forecast.Date = forecast.Date.AddDays(numberOfForecastsAlreadyLoopedThrough);
                numberOfForecastsAlreadyLoopedThrough++;
            }
            return fakeForecast;
        }

        private static IEnumerable<WeatherForecast> GetFakeForecast()
        {
            return new WeatherForecast[]
            {
                new WeatherForecast()
                {
                    City=new City() { Name="Namur", Country="Be" },
                     Date=DateTime.Now.Date,
                      Description="Brumeux",
                       MaxTemperature=13,
                        MinTemperature=5,
                         RainLevel=0

                },
                new WeatherForecast()
                {
                    City=new City() { Name="Arlon", Country="Be" },
                     Date=DateTime.Now.Date,
                      Description="Ensoleillé",
                       MaxTemperature=19,
                        MinTemperature=6,
                         RainLevel=0

                },
                new WeatherForecast()
                {
                    City=new City() { Name="Gembloux", Country="Be" },
                     Date=DateTime.Now.Date,
                      Description="Pluvieux",
                       MaxTemperature=11,
                        MinTemperature=7,
                         RainLevel=68

                },
                new WeatherForecast()
                {
                    City=new City() { Name="Floreffe", Country="Be" },
                     Date=DateTime.Now.Date,
                      Description="Brumeux",
                       MaxTemperature=15,
                        MinTemperature=8,
                         RainLevel=0

                },
            };
        }


    }
}
