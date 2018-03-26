using System;
using System.Globalization;
using Xamarin.Forms;

namespace Interpretap.Converter
{
    public class IsManagerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!string.IsNullOrWhiteSpace(value.ToString()))
            {
                if (value as string == "Yes")
                    return "Manager";
                else if (value as string == "No")
                    return "Not a Manager";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
