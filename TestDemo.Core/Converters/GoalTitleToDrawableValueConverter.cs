using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform.Converters;
using System.Globalization;
using Android;
using System.Diagnostics;

namespace TestDemo.Core.Converters
{
    public class GoalTitleToDrawableValueConverter : MvxValueConverter<string, string>
    {
        protected override string Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            
            string drawableName = value.ToLower().Replace(" ","");
            return drawableName;
            
        }
    }
   
}