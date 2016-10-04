using MvvmCross.Droid.Views;
using MvvmCross.Core.ViewModels;
using TestDemo.Core.ViewModels;
using Android.App;
using Android.OS;

namespace TestDemo.Droid.Views
{
    [MvxViewFor(typeof(SettingsViewModel))]
    [Activity(Label = "View for SettingsViewModel")]
    public class SettingsView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SettingsView);
        }
    }
}