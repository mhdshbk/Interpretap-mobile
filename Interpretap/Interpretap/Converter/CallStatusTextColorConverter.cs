using System;
using System.Globalization;
using Xamarin.Forms;

namespace Interpretap.Converter
{
    public class CallStatusTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!string.IsNullOrWhiteSpace(value.ToString()))
            {
                if (value as string == "Call Active")
                    return Color.FromHex("#f37a3f");
                else if (value as string == "Call Paused")
                    return Color.FromHex("#2e86c1");
                else if (value as string == "Call Finished")
                    return Color.Lime;
                else if (value as string == "Call Cancelled")
                    return Color.Red;
                else
                    return Color.White;
            }
            else
                return Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
