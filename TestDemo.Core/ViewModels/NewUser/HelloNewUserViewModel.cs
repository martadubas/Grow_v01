using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using TestDemo.Core.Database;
using TestDemo.Core.Models;
using TestDemo.Core.Interfaces;
using Android.Graphics.Drawables;

namespace TestDemo.Core.ViewModels
{
    public class HelloNewUserViewModel
         : MvxViewModel
    {
        private UserDatabase _userDatabase;
        private User _user = new User();
        private string _h1HelloUser;
        private string _imageChosenAvatar;


        public override void Start()
        {
            base.Start();
            var user = _userDatabase.GetUserById(1);
            h1HelloUser = "Let's start, " + user.Username;
           var avatar = user.Avatar;
            ImagePath = "bird";
        }
   
  public string ImagePath {
            get { return _imageChosenAvatar; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _imageChosenAvatar, value);
                }
            }
        }
    
    public string h1HelloUser
        {
            get { return _h1HelloUser; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _h1HelloUser, value);
                }
            }
        }

        public HelloNewUserViewModel(ISqlite sqlite)
        {
            _userDatabase = new UserDatabase();
        }

    }
}
