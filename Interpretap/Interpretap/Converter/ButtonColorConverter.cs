using System;
using System.Globalization;
using Xamarin.Forms;

namespace Interpretap.Converter
{
    public class ButtonColorConverter : IValueConverter
    {
        public ButtonColorConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var res = (bool)value;
            if (res)
                return "#2e86c1";
            else
                return "#c7c7c7";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
