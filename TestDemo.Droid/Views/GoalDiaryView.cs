//author: Elvin Prananta
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;

namespace TestDemo.Droid.Views
{
    [Activity(Label = "", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class GoalDiaryView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.GoalDiaryView);

            // Create your application here
            TextView title = (TextView)FindViewById(Resource.Id.textview_title);
            title.Text = "Goal Diary";

            TextView comment = (TextView)FindViewById(Resource.Id.textview_comment);
            comment.Text = "These are all the records of the goals.";
        }
    }
}