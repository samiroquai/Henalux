using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace WeatherApp.Helpers
{
    //Sous WPF on peut utiliser StringFormat directement dans le binding,
    //Mais ça n'a pas été porté sous UWP. => on a besoin d'un convertisseur!
    //credits: https://marcominerva.wordpress.com/2013/04/26/stringformat-converter-for-windows-store-apps/
    public sealed class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            if (parameter == null)
                return value;

            return string.Format((string)parameter, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            string language)
        {
            throw new NotImplementedException();
        }
    }
}
