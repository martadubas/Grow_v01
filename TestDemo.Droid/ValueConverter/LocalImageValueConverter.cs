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
            //level 1
            if (value == "bird1")
                image = Resource.Drawable.bird_1;
            if (value == "butterfly1")
                image = Resource.Drawable.butterfly_1;
            if (value == "diamond1")
                image = Resource.Drawable.diamond_1;
            //level 2
            if (value == "bird2")
                image = Resource.Drawable.bird_02;
            if (value == "butterfly2")
                image = Resource.Drawable.butterfly_02;
            if (value == "diamond2")
                image = Resource.Drawable.diamond_02;
            //level 3
            if (value == "bird3")
                image = Resource.Drawable.bird_03;
            if (value == "butterfly3")
                image = Resource.Drawable.buterfly_03;
            if (value == "diamond3")
                image = Resource.Drawable.diamond_03;

            //shadows 
            if (value == "butterfly2_shadow")
                image = Resource.Drawable.butterfly_02_shadow;
            if (value == "butterfly3_shadow")
                image = Resource.Drawable.butterfly_03_shadow;
            if (value == "diamond2_shadow")
                image = Resource.Drawable.diamond_02_shadow;
            if (value == "diamond3_shadow")
                image = Resource.Drawable.diamond_03_shadow;
            if (value == "bird2_shadow")
                image = Resource.Drawable.bird_02_shadow;
            if (value == "bird3_shadow")
                image = Resource.Drawable.bird_03_shadow;

            //ok
            if (value == "ok")
                image = Resource.Drawable.ok;



            return image;
        }
    }
}