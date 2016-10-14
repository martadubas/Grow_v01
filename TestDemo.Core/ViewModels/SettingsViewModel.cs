using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using TestDemo.Core.Database;

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

                    GoalDatabase _goalDatabase = new GoalDatabase();
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
