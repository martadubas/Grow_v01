//Author: Elvin Prananta, N9806482
using MvvmCross.Core.ViewModels;

namespace TestDemo.Core.ViewModels
{
    public class HomeViewModel 
        : MvxViewModel
    {


        public IMvxCommand GoalDiaryViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<GoalDiaryViewModel>());
            }
        }

        public IMvxCommand JourneyViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<JourneyViewModel>());
            }
        }

        public IMvxCommand MyGoalViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<MyGoalViewModel>());
            }
        }
        public IMvxCommand GoalListViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<GoalListViewModel>());
            }
        }
        public IMvxCommand SettingsViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<SettingsViewModel>());
            }
        }

        public IMvxCommand NewUserViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<HelloNewUserViewModel>());
            }
        }

    }
}


