using System;
using System.Collections.Generic;
using System.Globalization;
using System.Diagnostics;

using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform.Converters;

namespace TestDemo.Droid.ValueConverter
{
    public class StatusToDrawableValueConverter : MvxValueConverter<string,int>
    {
        protected override int Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.WriteLine("###### Status drawable converter");

            int image = 0;
            if (value.Contains("STARTED"))
            {
                Debug.WriteLine("###### started = ");
                image = Resource.Drawable.status_started;
            }else if (value.Contains("COMPLETED"))
            {
                image = Resource.Drawable.status_completed;

            }
            else if (value.Contains("EXPIRED"))
            {
                image = Resource.Drawable.status_expired;
            }
            else if (value.Contains("DELETED"))
            {
                image = Resource.Drawable.status_deleted;
            }
                    



            return image;
        }
    }
}