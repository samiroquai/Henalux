using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public interface IWeatherService
    {
        Task<WeatherForecast> GetCurrentWeatherByCityAsync(City city);
        Task<IEnumerable<WeatherForecast>> GetForecastByCityAsync(City city);
    }
}