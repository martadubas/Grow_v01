using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IMvxCommand HelloNewUserViewCommand
        {
            get
            {
                //if(_user.Avatar != null)
                {
                    return new MvxCommand(() => ShowViewModel<HelloNewUserViewModel>());
                }

                //return null;
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

