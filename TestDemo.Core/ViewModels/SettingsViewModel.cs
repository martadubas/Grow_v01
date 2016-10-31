//authors: Elvin Prananta and Marta Dubas, only for testing 
using MvvmCross.Core.ViewModels;
using TestDemo.Core.Database;
using TestDemo.Core.Models;

namespace TestDemo.Core.ViewModels
{
    class SettingsViewModel
         : MvxViewModel

    { 

        public IMvxCommand InfoNewUserCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<InfoNewUserViewModel>());
            }
        }

        public IMvxCommand ClearGoalDBCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    var _user = new User();
                    GoalDatabase _goalDatabase = new GoalDatabase();
                    UserDatabase _userDatabase = new UserDatabase();
                    _user = _userDatabase.GetUserById(1);
                    _user.CompletedGoal = 0;
                    var x = _userDatabase.Update(_user);
                    await _goalDatabase.DeleteAll();
                    ShowViewModel<GoalListViewModel>();
                });
            }
        }
        public IMvxCommand ClearSelectedGoalDBCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {

                    SelectedGoalDatabase _selectedGoalDatabase = new SelectedGoalDatabase();
                    await _selectedGoalDatabase.DeleteAll();
                    ShowViewModel<GoalDiaryViewModel>();
                });
            }
        }


    }
}
