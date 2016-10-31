//author:Marta Dubas
using MvvmCross.Core.ViewModels;

namespace TestDemo.Core.ViewModels
{
    class InfoNewUserViewModel
         : MvxViewModel
    {
        public IMvxCommand NewUserViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<NewUserViewModel>());
            }
        }
    }
}
