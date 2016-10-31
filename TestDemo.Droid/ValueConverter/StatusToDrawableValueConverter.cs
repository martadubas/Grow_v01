//author: Elvin Prananta
using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace TestDemo.Droid.ValueConverter
{
    public class StatusToDrawableValueConverter : MvxValueConverter<string,int>
    {
        protected override int Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
           
            int image = 0;
            if (value.Contains("STARTED"))
            {
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