//Author: Zeyuan Liu, N9557296

using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace TestDemo.Droid.Views
{
    [Activity(Label = "View for LevelViewModel")]
    public class LevelView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LevelView);
            //ert
        }
    }
}
