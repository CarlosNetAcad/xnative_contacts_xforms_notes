using System;
using System.Globalization;
using Xamarin.Forms;

namespace NotesForms.Converters
{
    public class IntToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var input = value as String;

            if (input != null)
                return int.TryParse(input,out _);

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

