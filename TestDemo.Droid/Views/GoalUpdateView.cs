using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.OS;

using MvvmCross.Droid.Views;
using Android.Widget;
using TestDemo.Core.ViewModels;

namespace TestDemo.Droid.Views
{
    [Activity(Label = "", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class GoalUpdateView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GoalUpdateView);

            // Create your application here
            GoalUpdateViewModel vm = (GoalUpdateViewModel)ViewModel;
            Button btnDelete = FindViewById<Button>(Resource.Id.button_delete);
            Button btnComplete = FindViewById<Button>(Resource.Id.button_complete);


            if (vm.Status.Equals("STARTED"))
            {
                btnComplete.Visibility = Android.Views.ViewStates.Visible;
                btnDelete.Visibility = Android.Views.ViewStates.Visible;
            }else
            {
                //for COMPLETED DELETED EXPIRED goal
                btnComplete.Visibility = Android.Views.ViewStates.Gone;
                btnDelete.Visibility = Android.Views.ViewStates.Gone;
            }

            string message = "toast mesage";
            btnComplete.Click += delegate
            {

                if (btnComplete.Text.Equals("Restore"))
                {
                    message = "Goal re-started";

                }
                else
                {
                    message = "Congrats :D goal completed!";

                }
                Toast.MakeText(this, message, ToastLength.Short).Show();
                
            };

            btnDelete.Click += delegate
            {
                message = "Goal Deleted";
                Toast.MakeText(this, message, ToastLength.Short).Show();

            };

        }
    }
}