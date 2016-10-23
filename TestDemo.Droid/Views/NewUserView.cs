//Author: Marta Dubas, N9791701

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using TestDemo.Core.ViewModels;

namespace TestDemo.Droid.Views
{
    [Activity(Label = "", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class NewUserView : MvxActivity
    {
        private NewUserViewModel _viewModel;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.NewUserView);
            _viewModel = (NewUserViewModel)ViewModel;

            EditText editTxtNewUser = FindViewById<EditText>(Resource.Id.editTxtNewUser);
            Button btnNewUser = FindViewById<Button>(Resource.Id.btnNewUser);

            btnNewUser.Click += delegate
            {
                if (editTxtNewUser.Text == "")
                {
                    Toast.MakeText(this, "Write your username", ToastLength.Short).Show();
                }

            };
         }
    }
}


