using System;
using System.Globalization;
using Xamarin.Forms;

namespace NotesForms.Converters
{
    public class StringToBoolConverter : IValueConverter
    {
        const int MIN_LENGTH = 6;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = value as String;

            if (text != null &&
                text.Length >= MIN_LENGTH)
                return true;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

