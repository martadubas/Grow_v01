using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.OS;

using MvvmCross.Droid.Views;

namespace TestDemo.Droid.Views
{
    [Activity(Label = "My Goal")]
    public class GoalUpdateView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GoalUpdateView);

            // Create your application here
        }
    }
}