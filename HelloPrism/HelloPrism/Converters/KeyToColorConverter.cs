using System;
using System.Globalization;
using Xamarin.Forms;

namespace HelloPrism.Converters
{
    public class DateTimeToTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTimeToBeConverted = (DateTime)value;

            var dateTimeNow = DateTime.Now;

            var startOfToday = new DateTime(dateTimeNow.Year, dateTimeNow.Month, dateTimeNow.Day);

            if (DateTime.Compare(dateTimeToBeConverted, startOfToday) < 0 &&
                Application.Current.Resources.TryGetValue("RedText", out var redColor))
                return redColor;
            else if (DateTime.Compare(dateTimeToBeConverted, startOfToday.AddDays(10)) > 0 &&
                Application.Current.Resources.TryGetValue("BlackText", out var blackColor))
                return blackColor;
            else if (Application.Current.Resources.TryGetValue("YellowText", out var yellowColor))
                return yellowColor;

            return Color.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new InvalidOperationException("Conversion back to DateTime is not supported");
        }
    }
}
