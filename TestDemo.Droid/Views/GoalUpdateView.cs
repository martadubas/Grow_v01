//author: Elvin Prananta
using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using Android.Widget;
using TestDemo.Core.ViewModels;
using Android.Views;

namespace TestDemo.Droid.Views
{
    [Activity(Label = "", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class GoalUpdateView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.GoalUpdateView);

            // Create your application here
            GoalUpdateViewModel vm = (GoalUpdateViewModel)ViewModel;
            Button btnDelete = FindViewById<Button>(Resource.Id.button_delete);
            Button btnComplete = FindViewById<Button>(Resource.Id.button_complete);
            Button btnPhoto = FindViewById<Button>(Resource.Id.button_photo);


            if (vm.Status.Equals("STARTED"))
            {
                btnComplete.Visibility = Android.Views.ViewStates.Visible;
                btnDelete.Visibility = Android.Views.ViewStates.Visible;
                btnPhoto.Visibility = Android.Views.ViewStates.Gone;
            }
            else if (vm.Status.Equals("COMPLETED"))
            {
                btnComplete.Visibility = Android.Views.ViewStates.Gone;
                btnDelete.Visibility = Android.Views.ViewStates.Gone;
                btnPhoto.Visibility = Android.Views.ViewStates.Visible;
            }
            else
            {
                //for DELETED and EXPIRED goal
                btnComplete.Visibility = Android.Views.ViewStates.Gone;
                btnDelete.Visibility = Android.Views.ViewStates.Gone;
                btnPhoto.Visibility = Android.Views.ViewStates.Gone;
            }

            string message = "toast message";
            btnComplete.Click += delegate
            {

                if (btnComplete.Text.Equals("Restore"))
                {
                    message = "Goal re-started";

                }
                else
                {
                    message = "Congratulations! Goal completed!";

                }
                Toast.MakeText(this, message, ToastLength.Short).Show();
                
            };

            btnDelete.Click += delegate
            {
                message = "Goal Deleted";
                Toast.MakeText(this, message, ToastLength.Short).Show();

            };

        }
    }
}