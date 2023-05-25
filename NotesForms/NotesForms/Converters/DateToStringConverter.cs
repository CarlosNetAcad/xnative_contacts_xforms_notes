using System;
using System.Globalization;
using Xamarin.Forms;

namespace NotesForms.Converters
{
	public class DateToStringConverter:IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DateTime date)
            {
                var defaultFormat = "MM/dd/yy";

                if (parameter != null) defaultFormat = parameter as string;

                return date.ToString( defaultFormat );
            }

            return value;            

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

