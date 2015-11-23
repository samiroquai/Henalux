using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class WeatherForecast
    {
        public City City { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public double MaxTemperature { get; set; }
        public double MinTemperature { get; set; }
        public double RainLevel { get; set; }
    }
}
