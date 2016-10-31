using MvvmCross.Platform.Converters;
using System;
//author: Elvin Prananta
using System.Globalization;

namespace TestDemo.Core.Converters
{
    public class FormatDateValueConverter : MvxValueConverter<DateTime, string>
    {
        protected override string Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString("MMM d, ddd");
        }       

    }
}

