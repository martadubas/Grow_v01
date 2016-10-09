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
        
        private readonly UserDatabase _userDatabase;
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
                    var users  = _userDatabase.GetUser();
                    
                    if (string.IsNullOrEmpty(Username))
                    {
                        Debug.WriteLine("Throw exception, username is empty");
                    }
                    else
                    {
                
                      _user.Username = Username;
                        if (_userDatabase.isSetUser())
                        {
                           // _userDatabase.Update(_user);
                            _userDatabase.DeleteAll();
                            _userDatabase.InsertUser(_user);
                            ShowViewModel<ChooseAvatarViewModel>();
                        }
                        else
                        {
                            //add
                            _userDatabase.InsertUser(_user);
                            ShowViewModel<ChooseAvatarViewModel>();
                        }
                       
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