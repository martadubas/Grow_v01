//Author: Elvin Prananta, N9806482
using MvvmCross.Core.ViewModels;

namespace TestDemo.Core.ViewModels
{
    public class HomeViewModel 
        : MvxViewModel
    {
     
        public IMvxCommand NewUserCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<NewUserViewModel>());
            }
        }

        public IMvxCommand LevelViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<LevelViewModel>());
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
