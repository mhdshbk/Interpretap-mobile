using System;
using System.Globalization;
using Xamarin.Forms;

namespace Interpretap.Converter
{
    public class DateFormatConverter : IValueConverter
    {
        public DateFormatConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date;
            string result;

            var res = value as string;
            var x = DateTime.TryParse(res,out date);
            if (x)
            {
                result = date.ToString("MMM dd,") + Environment.NewLine + date.ToString("HH:mm:ss");
                return result;
            }
            else
                return string.Empty;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
