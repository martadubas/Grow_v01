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
        private string _shadow1;
        private string _shadow2;
        private string _pointsLevel2;
        private string _pointsLevel3;
        private readonly IDialogService dialog;

        public override void Start()
        {
            base.Start();      
            _user = _userDatabase.GetUserById(1);
            var avatar = _user.Avatar;
            var points = _user.CompletedGoal;
            _h1Journey = _user.Username + "'s journey";


            if (points < 20)
            {
                _user.AvatarLevel = 1;
                var x = _userDatabase.Update(_user);

                _pointsLevel2 = points.ToString() + "/20";
                _pointsLevel3 = "0/20";
        
                switch (avatar)
                {

                    case 0:
                        JourneyImagePath = "bird1";
                        JourneyShadow1 = "bird2_shadow";
                        JourneyShadow2 = "bird3_shadow";
                        break;

                    case 1:
                        JourneyImagePath = "butterfly1";
                        JourneyShadow1 = "butterfly2_shadow";
                        JourneyShadow2 = "butterfly3_shadow";
                        break;

                    case 2:
                        JourneyImagePath = "diamond1";
                        JourneyShadow1 = "diamond2_shadow";
                        JourneyShadow2 = "diamond3_shadow";
                        break;

                    default:
                        JourneyImagePath = "bird1";
                        JourneyShadow1 = "bird2_shadow";
                        JourneyShadow2 = "bird3_shadow";
                        break;
                }

            }

            if (points >= 20 && points < 40)

            {

                _pointsLevel2 = "20/20";
                _pointsLevel3 = (points - 20).ToString() + "/20";

                if (points == 20 & _user.AvatarLevel<= 1)
                {
                    _user.AvatarLevel = 2;
                    var x = _userDatabase.Update(_user);
                    dialog.Show("Congratulations!", "Your avatar has grown!", "OK");
                }
                
                switch (avatar)
                {

                    case 0:
                        JourneyImagePath = "bird2";
                        JourneyShadow1 = "ok";
                        JourneyShadow2 = "bird3_shadow";
                        break;

                    case 1:
                        JourneyImagePath = "butterfly2";
                        JourneyShadow1 = "ok";
                        JourneyShadow2 = "butterfly3_shadow";
                        break;

                    case 2:
                        JourneyImagePath = "diamond2";
                        JourneyShadow1 = "ok";
                        JourneyShadow2 = "diamond3_shadow";
                        break;

                    default:
                        JourneyImagePath = "bird2";
                        JourneyShadow1 = "ok";
                        JourneyShadow2 = "bird3_shadow";
                        break;
                }
            }
            else if (points >= 40)
            {
                _pointsLevel2 = "20/20";
                _pointsLevel3 = "20/20";

                if (points == 40 & _user.AvatarLevel == 2)
                {
                    _user.AvatarLevel = 3;
                    var x = _userDatabase.Update(_user);
                    dialog.Show("Congratulations!", "Your avatar has grown!", "OK");
                }


                switch (avatar)
                {

                    case 0:
                        JourneyImagePath = "bird3";
                        JourneyShadow1 = "ok";
                        JourneyShadow2 = "ok";
                        break;

                    case 1:
                        JourneyImagePath = "butterfly3";
                        JourneyShadow1 = "ok";
                        JourneyShadow2 = "ok";
                        break;

                    case 2:
                        JourneyImagePath = "diamond3";
                        JourneyShadow1 = "ok";
                        JourneyShadow2 = "ok";
                        break;

                    default:
                        JourneyImagePath = "bird3";
                        JourneyShadow1 = "ok";
                        JourneyShadow2 = "ok";
                        break;
                }
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
                return new MvxCommand(() => dialog.Show("Not available yet", "This functionality will come in the next version", "OK"));
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

        public string JourneyShadow2
        {
            get { return _shadow2; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _shadow2, value);
                }
            }
        }

        public string JourneyShadow1
        {
            get { return _shadow1; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _shadow1, value);
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

        public JourneyViewModel(ISqlite sqlite, IDialogService dialog)
        {
            this.dialog = dialog;
            _userDatabase = new UserDatabase();
            
            
        }
  

        public string pointsLevel2
        {
            get { return _pointsLevel2; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _pointsLevel2, value);
                }
            }
        }

        public string pointsLevel3
        {
            get { return _pointsLevel3; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _pointsLevel3, value);
                }
            }
        }


    }
}
