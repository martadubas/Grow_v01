//author:Marta Dubas
using System;
using MvvmCross.Platform.Converters;
using Android.Graphics;
using System.Globalization;

namespace TestDemo.Droid.ValueConverter
{
    public class ByteArrayToBitmapValueConverter :MvxValueConverter<byte[],Bitmap>
    {
        protected override Bitmap Convert(byte[] value, Type targetType, object parameter, CultureInfo culture)
        {
            var photo = BitmapFactory.DecodeByteArray(value, 0, value.Length);
            return photo;
        }
    }
}