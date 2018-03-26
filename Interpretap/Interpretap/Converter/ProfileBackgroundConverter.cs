using System;
using System.Globalization;
using Interpretap.ViewModels;
using Xamarin.Forms;

namespace Interpretap.Converter
{
    public class ProfileBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var res = value as string;

            if (res == "Client")
                return Color.FromHex("#f37a3f");
            else
                return Color.FromHex("#2e86c1");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
