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
        ChooseAvatarViewModel vm;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            vm = ViewModel as ChooseAvatarViewModel;
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ChooseAvatarView);


            Gallery gallery = (Gallery)FindViewById<Gallery>(Resource.Id.galleryChooseAvatar);

            gallery.Adapter = new ImageAdapter(this);

            gallery.ItemClick += delegate (object sender, Android.Widget.AdapterView.ItemClickEventArgs args) {
                vm.SetAvatar(args.Position);
            };
        }
    }
}