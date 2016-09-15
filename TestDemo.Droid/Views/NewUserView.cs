//Author: Marta Dubas, N9791701

using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace TestDemo.Droid.Views
{
    [Activity(Label = "")]
    public class NewUserView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.NewUserView);
            //ert
        }
    }
}
