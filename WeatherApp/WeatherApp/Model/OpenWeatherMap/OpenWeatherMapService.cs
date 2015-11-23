using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model.OpenWeatherMap
{
    public class OpenWeatherMapService : IWeatherService
    {
        private const string API_KEY = "91264df652e6981bb4b00343c55bd262";



        public async Task<WeatherForecast> GetCurrentWeatherByCityAsync(City city)
        {
            var u = new Uri("http://api.openweathermap.org/data/2.5/weather?q=" + city.Name + "," + city.Country + "&appid=" + API_KEY + "&lang=fr&units=metric");
            //throw new NotImplementedException();
            WeatherService s = new WeatherService();
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(u);
            var response = JsonConvert.DeserializeObject<CurrentWeatherModel.RootObject>(json);
            WeatherForecast forecast = null;

            DateTime dtDateTime = GetDateTime(response.dt);

            return new WeatherForecast()
            {
                City = city,
                Date = dtDateTime,
                Description = response.weather.First().description,
                MaxTemperature = response.main.temp_max,
                MinTemperature = response.main.temp_min,
            };

        }

        private static DateTime GetDateTime(long dt)
        {
            //dt est un moment Unix => il faut le convertir en DateTime C#
            //credits: http://stackoverflow.com/questions/249760/how-to-convert-a-unix-timestamp-to-datetime-and-vice-versa
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(dt).ToLocalTime();
            return dtDateTime;
        }

        public async Task<IEnumerable<WeatherForecast>> GetForecastByCityAsync(City city)
        {
            var u = new Uri("http://api.openweathermap.org/data/2.5/forecast/daily?q=" + city.Name + "," + city.Country + "&appid=" + API_KEY + "&lang=fr&units=metric");
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(u);
            var response = JsonConvert.DeserializeObject<ForecastModel.RootObject>(json);
            List<WeatherForecast> forecast = new List<WeatherForecast>();
            foreach (var weatherDescription in response.list)
            {
                foreach (var detailedWeatherDescription in weatherDescription.weather)
                {
                    forecast.Add(new WeatherForecast()
                    {
                        City = city,
                        Date = GetDateTime(weatherDescription.dt),
                        Description = detailedWeatherDescription.description,
                        MaxTemperature = weatherDescription.temp.max,
                        MinTemperature = weatherDescription.temp.min,
                    });
                }
            }
            return forecast;
        }
    }
}
