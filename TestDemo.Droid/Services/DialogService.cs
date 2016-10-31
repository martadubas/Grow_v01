using System;
using Android.App;
using System.Threading.Tasks;
using TestDemo.Core.Interfaces;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace TestDemo.Droid.Services
{
    public class DialogService : IDialogService
    {
        Dialog dialog = null;

        public async Task<bool> Show(string message, string title)
        {
            return await Show(message, title, "OK");
        }

        public async Task<bool> Show(string message, string title, string confirmButton)
        {
            bool buttonPressed = false;
            bool chosenOption = false;
            Application.SynchronizationContext.Post(_ =>
            {
                var mvxTopActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
                AlertDialog.Builder alertDialog = new AlertDialog.Builder(mvxTopActivity.Activity,5);
           
                alertDialog.SetTitle(title);
                alertDialog.SetMessage(message);
               
               
                alertDialog.SetPositiveButton(confirmButton, (s, args) =>
                {
                    chosenOption = true;
                });

                dialog = alertDialog.Create();

                dialog.DismissEvent += (object sender, EventArgs e) =>
                {
                    buttonPressed = true;
                    dialog.Dismiss();
                };
                dialog.Show();
            
            }, null);
            while (!buttonPressed)
            {
                await Task.Delay(100);
            }
            return chosenOption;
        }
    }
}