//author: Elvin Prananta
using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Views;

namespace TestDemo.Droid.Views
{
    [Activity(Label = "", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class GoalListView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.GoalListView);

        }
    }
}