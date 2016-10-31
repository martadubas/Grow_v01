//Author: Elvin Prananta, N9806482
using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Views;

namespace TestDemo.Droid.Views
{
    [Activity(Label = "", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class HomeView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.HomeView);
            
        }
    }
}
