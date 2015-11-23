using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using WeatherApp.Model;
using WeatherApp.Model.OpenWeatherMap;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeatherApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            var cities = await LoadCitiesAsync();
            await LoadWeatherAsync(cities);
        }

        private async Task<IEnumerable<City>> LoadCitiesAsync()
        {
            var service = new CitiesService();
            var cities = await service.LoadCitiesAsync();
            return cities;
        }

        private async Task LoadWeatherAsync(IEnumerable<City> cities)
        {
            var service = new OpenWeatherMapService();
            List<WeatherForecast> forecast = new List<WeatherForecast>();
            foreach (var cityFollowed in cities)
            {
                var weather = await service.GetCurrentWeatherByCityAsync(cityFollowed);
                forecast.Add(weather);
            }
            Forecast.ItemsSource = forecast;
        }
    }
}
