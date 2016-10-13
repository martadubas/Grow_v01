//Author: Marta Dubas, N9791701
using MvvmCross.Core.ViewModels;
using System.Diagnostics;
using System.Windows.Input;
using TestDemo.Core.Database;
using TestDemo.Core.Interfaces;
using TestDemo.Core.Models;

namespace TestDemo.Core.ViewModels
{
    public class NewUserViewModel
        : MvxViewModel
    {
        
        private  UserDatabase _userDatabase;
        private User _user = new User();
        private string _username;
       
      

        public string Username
        {
            get { return _username; }
            set
            {
                if(value != null && value != _username)
                {
                    _username = value;
                    RaisePropertyChanged(() => Username);
                }
            }
        }


        public ICommand ConfirmUsernameCommand
        {
           
            get
            {
                return new MvxCommand(() =>
                {
                    //var users  = _userDatabase.GetUsers();
          
                    if (string.IsNullOrEmpty(Username))
                    {
                        Debug.WriteLine("Throw exception, username is empty");
                    }
                    else
                    {
                      if (_userDatabase.GetUserById(1) != null)
                        {
                            _user = _userDatabase.GetUserById(1);
                            _user.Username = Username;
                            _user.Avatar = 99;
                            var x =_userDatabase.Update(_user);
                            
                           
                        }
                        else
                        {
                            _user.Username = Username;
                            _user.Id = 1;
                            var y =_userDatabase.InsertUser(_user);
                            
                        }
                        ShowViewModel<ChooseAvatarViewModel>();
                    }
                });
                
            }

        }

        public NewUserViewModel(ISqlite sqlite)
        {
            _userDatabase = new UserDatabase();
           }

    }

   
}