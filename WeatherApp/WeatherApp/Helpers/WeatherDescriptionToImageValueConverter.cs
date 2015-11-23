using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace WeatherApp.Helpers
{
    public class WeatherDescriptionToImageValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        { 
            string weatherDescription = value as string;
            if (weatherDescription == null)
                return null;
           switch(weatherDescription.ToLower())
            {
                case "ensoleillé":return new BitmapImage(new Uri("ms-appx://WeatherApp/Assets/Sunny.png"));
                default:return new BitmapImage(new Uri("ms-appx://WeatherApp/Assets/Cloudy.png"));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
