using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace WeatherApp.Helpers
{
    public class CollectionCountToVisibilityConverter : IValueConverter
    {

        public bool IsInverted { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var coll = value as IEnumerable<object>;
            if (coll == null)
                return Visibility.Collapsed;
            if (!IsInverted)
                return coll.Any() ? Visibility.Visible : Visibility.Collapsed;
            else
                return coll.Count() == 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
