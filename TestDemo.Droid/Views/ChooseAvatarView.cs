using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using TestDemo.Core.ViewModels;

namespace TestDemo.Droid.Views
{
    [Activity(Label = "",ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]

    public class ChooseAvatar : MvxActivity
    {
       private ChooseAvatarViewModel _viewModel;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {   
              base.OnCreate(savedInstanceState);
            this.RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.ChooseAvatarView);
            _viewModel = (ChooseAvatarViewModel)ViewModel;

            SendAvatarId();
           
        }

        public void SendAvatarId()
    {
        Gallery gallery = FindViewById<Gallery>(Resource.Id.galleryChooseAvatar);

        gallery.Adapter = new ImageAdapter(this);

        gallery.ItemSelected += delegate (object sender, Android.Widget.AdapterView.ItemSelectedEventArgs args) {

            var pos = args.Position;
            _viewModel.SetAvatar(pos);
        };
        }
    }
}