using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo.Core.Converters
{
    public class FormatDateValueConverter : MvxValueConverter<DateTime, string>
    {

        protected override string Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            //Debug.WriteLine("################ converter");
            return value.ToString("MMM d, ddd");
        }       

    }
}

