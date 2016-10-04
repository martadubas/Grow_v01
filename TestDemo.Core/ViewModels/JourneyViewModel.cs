
using MvvmCross.Core.ViewModels;


namespace TestDemo.Core.ViewModels
{
    class JourneyViewModel
         : MvxViewModel
    {
        public IMvxCommand HomeViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<HomeViewModel>());
            }
        }

        public IMvxCommand HelloNewUserCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<HelloNewUserViewModel>());
            }
        }


    }
}
