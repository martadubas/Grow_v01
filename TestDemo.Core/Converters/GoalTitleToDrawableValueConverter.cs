//author: Elvin Prananta
using System;
using MvvmCross.Platform.Converters;
using System.Globalization;
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