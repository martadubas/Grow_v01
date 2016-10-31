//author:Marta Dubas
using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Views;
using TestDemo.Core.ViewModels;

namespace TestDemo.Droid.Views
{
    [Activity(Label = "", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class HelloNewUserView : MvxActivity
    {
        private HelloNewUserViewModel _viewModel;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.HelloNewUserView);
            _viewModel = (HelloNewUserViewModel)ViewModel;

        }
    }
}