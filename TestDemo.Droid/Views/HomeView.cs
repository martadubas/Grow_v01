//Author: Elvin Prananta, N9806482

using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace TestDemo.Droid.Views
{
    [Activity(Label = "View for HomeViewModel")]
    public class HomeView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HomeView);
            
        }
    }
}
