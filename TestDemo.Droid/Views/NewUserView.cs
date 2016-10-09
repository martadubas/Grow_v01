//Author: Marta Dubas, N9791701

using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using TestDemo.Core.ViewModels;

namespace TestDemo.Droid.Views
{
    [Activity(Label = "")]
    public class NewUserView : MvxActivity
    {
        private NewUserViewModel _viewModel;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.NewUserView);
            _viewModel = (NewUserViewModel)ViewModel;
            
        }
    }
}
