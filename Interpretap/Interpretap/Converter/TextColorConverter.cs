using System;
using System.Globalization;
using Interpretap.ViewModels;
using Xamarin.Forms;

namespace Interpretap.Converter
{
    public class TextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var res = value as ProfileSelectorItemViewModel;

            if (res.ProfileTypeCaption == "Client")
                return "Black";
            else
                return "White";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
