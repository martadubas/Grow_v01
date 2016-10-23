using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.OS;

using MvvmCross.Droid.Views;
using Android.Widget;
using TestDemo.Core.ViewModels;
using Android.Views;

namespace TestDemo.Droid.Views
{
    [Activity(Label = "", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class GoalDetailView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.GoalDetailView);


            GoalDetailViewModel vm = (GoalDetailViewModel)ViewModel;

            TextView goalTitle = FindViewById<TextView>(Resource.Id.textview_title);
            Button btnSelectGoal = FindViewById<Button>(Resource.Id.button_selectgoal);
            string message = "";
            btnSelectGoal.Click += delegate
            {
                if (goalTitle.Text.Contains("STARTED"))
                {
                    message = "You have started this goal ^^ Complete it and mark it in 'My Goal'";
                    Toast.MakeText(this, message, ToastLength.Long).Show();
                }else if (goalTitle.Text.Contains("COMPLETED"))
                {
                    message = "You have completed this goal today, try different goal to grow your avatar ^^";
                    Toast.MakeText(this, message, ToastLength.Long).Show();
                }
                else
                {
                    message = goalTitle.Text + " started";
                    Toast.MakeText(this, message, ToastLength.Short).Show();
                }
               

            };

            //for images
           String resourceId = "@drawable/" + vm.Title.ToLower().Trim(); // where myResourceName is the name of your resource file, minus the file extension
           //int imageResource = getResources().getIdentifier(resourceId, null, getPackageName());
           // Drawable drawable = ContextCompat.getDrawable(this, imageResource); // For API 21+, gets a drawable styled for theme of passed Context
           // imageview = (ImageView)findViewById(R.id.imageView);
           // imageview.setImageDrawable(drawable);
        }
    }
}