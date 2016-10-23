using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform.Converters;
using System.Globalization;
using Android;
using System.Diagnostics;
using System.Text.RegularExpressions;
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
            //Debug.WriteLine("###### color converter");
            String strvalue = (string)value;
            strvalue = strvalue.ToUpper();
            //Debug.WriteLine("###### strvalue = "+strvalue);

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


        /*
         *
         * 
         protected override MvxColor Convert(object value, object parameter, CultureInfo culture)
        {
            Debug.WriteLine("###### color converter");
            String strvalue = (string)value;
            strvalue = strvalue.ToUpper();
            Debug.WriteLine("###### strvalue = "+strvalue);

            if (strvalue.Contains("COMPLETED"))
            {
                return ColorCompleted;
            }
            else if (strvalue.Contains("STARTED"))
            {
                return ColorStarted;
            }
            else if (strvalue.Contains("EXPIRED"))
            {
                return ColorExpired;
            }
            else if (strvalue.Contains("DELETED"))
            {
                return ColorExpired;
            }
            else
            {
                return ColorDefault;
            }
        }
         *
         **/



    }

}