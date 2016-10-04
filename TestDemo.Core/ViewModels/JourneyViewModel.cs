using MvvmCross.Core.ViewModels;

namespace TestDemo.Core.ViewModels
{
    class JourneyViewModel
         : MvxViewModel
    {
        public IMvxCommand HomeViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<HomeViewModel>());
            }
        }
        public IMvxCommand InfoNewUserCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<InfoNewUserViewModel>());
            }
        }
        

        public IMvxCommand ShareOnFacebookCommand
        {
            get
            {
                
                //Context context = getApplicationContext();
                //string text = "Share on Facebook!";
                //int duration = Toast.LENGTH_SHORT;

                //Toast toast = Toast.makeText(context, text, duration);
                //toast.show();
                return null;
                //return new MvxCommand(() => ShowViewModel<HelloNewUserViewModel>());
            }

        }


    }
}
