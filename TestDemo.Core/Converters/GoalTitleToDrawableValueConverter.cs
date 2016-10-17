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
            //Debug.WriteLine("################### value : " + value);
            //Debug.WriteLine("################### drawable name : " + drawableName);
            return drawableName;
            //return "goal1";
            
        }
    }
    //public class DrawableValueConverter : MvxValueConverter<string, int>
    //{
    //    protected override int Convert(string value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        int image = 0;
    //        //        

    //        //image = Resource.Drawable.diamond_1;



    //        return image;
    //    }
    //}
}