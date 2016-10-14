using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform.Converters;
using System.Globalization;
using Android;

namespace TestDemo.Core.Converters
{
    public class DrawableSourceValueConverter : MvxValueConverter<string, int>
    {

        protected override int Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            int image = 0;
            if (value == "goal1")
            {
                //image = Resource.Drawable.goal1;
            }
            return image;
        }
    }
}