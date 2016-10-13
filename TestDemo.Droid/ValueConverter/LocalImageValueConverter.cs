using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform.Converters;

namespace TestDemo.Droid.ValueConverter
{
    public class LocalImageValueConverter : MvxValueConverter<string,int>
    {
        protected override int Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            int image = 0;
            if (value == "bird")
                image = Resource.Drawable.bird_1;

            return image;
        }
    }
}