using System;
using System.Globalization;
using Xamarin.Forms;

namespace HelloPrism.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTimeToConvert = (DateTime)value;

            return dateTimeToConvert.ToString("dd MMM yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new InvalidOperationException("Conversion back to DateTime is not supported");
        }
    }
}
