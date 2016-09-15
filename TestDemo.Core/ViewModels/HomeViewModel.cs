//Author: Elvin Prananta, N9806482
using MvvmCross.Core.ViewModels;

namespace TestDemo.Core.ViewModels
{
    public class HomeViewModel 
        : MvxViewModel
    {
     
        
        public IMvxCommand LevelViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<LevelViewModel>());
            }
        }

        public IMvxCommand JourneyViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<JourneyViewModel>());
            }
        }

        public IMvxCommand MedalsViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<MedalsViewModel>());
            }
        }
        public IMvxCommand TaskListViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<TaskListViewModel>());
            }
        }
        public IMvxCommand SettingsViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<SettingsViewModel>());
            }
        }



        //private bool isGoing;

        /*
        public bool IsGoing
        {
            get { return isGoing; }
            set
            {
                isGoing = value;
                RaisePropertyChanged();
            }
        }
        */


    }
}


