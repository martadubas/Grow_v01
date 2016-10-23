using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform.Converters;
using System.Globalization;
using Android;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace TestDemo.Core.Converters
{
    public class GoalTitleToDrawableValueConverter : MvxValueConverter<string, string>
    {
        protected override string Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            value = Regex.Replace(value, "(\\[.*\\])",""); //remove status from title when retrieving image
            value = value.ToLower().Replace(" ", "");
            return value;
            
        }
    }
   
}