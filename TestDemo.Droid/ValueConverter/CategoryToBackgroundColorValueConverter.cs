//author: Elvin Prananta
using System;
using System.Globalization;
using MvvmCross.Plugins.Color;
using MvvmCross.Platform.UI;

namespace TestDemo.Core.Converters
{
    public class CategoryToBackgroundColorValueConverter : MvxColorValueConverter
    {
        //list of random colours in RGBA
        private static readonly MvxColor ColorSport = new MvxColor(162, 215, 157, 100); // green
        private static readonly MvxColor ColorFood = new MvxColor(141, 174, 231, 100); //blue
        private static readonly MvxColor ColorRelax = new MvxColor(177, 174, 199, 100); //grey
        private static readonly MvxColor ColorSocial = new MvxColor(150, 141, 231, 100); //purple
        private static readonly MvxColor ColorOthers = new MvxColor(243, 93, 88, 91); //red

        protected override MvxColor Convert(object value, object parameter, CultureInfo culture)
        {
            String strvalue = (string)value;
            strvalue = strvalue.ToUpper();

            if (strvalue.Contains("FOOD"))
            {
                return ColorFood;
            }
            else if (strvalue.Contains("SOCIAL"))
            {
                return ColorSocial;
            }
            else if (strvalue.Contains("SPORT"))
            {
                return ColorSport;
            }
            else if (strvalue.Contains("RELAX"))
            {
                return ColorRelax;
            }
            else
            {
                return ColorOthers;
            }
        }
       
    }

}