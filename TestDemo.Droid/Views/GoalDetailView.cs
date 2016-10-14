using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.OS;

using MvvmCross.Droid.Views;
using Android.Widget;

namespace TestDemo.Droid.Views
{
    [Activity(Label = "Goals Details")]
    public class GoalDetailView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GoalDetailView);

            //_viewModel = (GoalDetailViewModel)ViewModel;

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

            // Create your application here
        }
    }
}