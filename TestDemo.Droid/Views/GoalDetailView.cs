using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.OS;

using MvvmCross.Droid.Views;

namespace TestDemo.Droid.Views
{
    [Activity(Label = "Goals Details")]
    public class GoalDetailView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GoalDetailView);

            // Create your application here
        }
    }
}