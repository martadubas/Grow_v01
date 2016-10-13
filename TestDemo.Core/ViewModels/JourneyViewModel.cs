using MvvmCross.Core.ViewModels;
using TestDemo.Core.Database;
using TestDemo.Core.Interfaces;
using TestDemo.Core.Models;

namespace TestDemo.Core.ViewModels
{
    class JourneyViewModel
         : MvxViewModel
    {
        private UserDatabase _userDatabase;
        private User _user = new User();
        private string _h1Journey;
        private string _imageChosenAvatar;

        public override void Start()
        {
            base.Start();
            var user = _userDatabase.GetUserById(1);
            _h1Journey = user.Username + "'s journey";
            var avatar = user.Avatar;

            switch (avatar)
            {

                case 0:
                    JourneyImagePath = "bird";
                    break;

                case 1:
                    JourneyImagePath = "butterfly";
                    break;

                case 2:
                    JourneyImagePath = "diamond";
                    break;

                default:
                    JourneyImagePath = "bird";
                    break;
            }

        }

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
        public string JourneyImagePath
        {
            get { return _imageChosenAvatar; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _imageChosenAvatar, value);
                }
            }
        }
        public string h1Journey
        {
            get { return _h1Journey; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _h1Journey, value);
                }
            }
        }

        public JourneyViewModel(ISqlite sqlite)
        {
            _userDatabase = new UserDatabase();
        }


    }
}
