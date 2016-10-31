//author: Marta Dubas
using MvvmCross.Core.ViewModels;
using TestDemo.Core.Models;
using TestDemo.Core.Database;
using TestDemo.Core.Interfaces;

namespace TestDemo.Core.ViewModels

{
    public class ChooseAvatarViewModel
         : MvxViewModel
    {
        private UserDatabase _userDatabase;
        private User _user = new User();
        private string _h1ChooseAvatar;


        public override void Start()
        {
            base.Start();
            var user = _userDatabase.GetUserById(1);
            h1ChooseAvatar = "Choose your avatar, " + user.Username;
        }




        public IMvxCommand HelloNewUserViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<HelloNewUserViewModel>());
            }
        }

        //public void Init()
        //{

        //}


        public string h1ChooseAvatar
        {
            get { return _h1ChooseAvatar; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _h1ChooseAvatar, value);
                }
            }
        }


        public void SetAvatar(int position)
        {
            _user = _userDatabase.GetUserById(1);
            switch (position)
            {
                case 0:
                    _user.Avatar = 0;

                    break;
                case 1:
                    _user.Avatar = 1;

                    break;
                case 2:
                    _user.Avatar = 2;

                    break;

            }
            _userDatabase.Update(_user);
        }

        public ChooseAvatarViewModel(ISqlite sqlite)
        {
            _userDatabase = new UserDatabase();
        }

    }
}

