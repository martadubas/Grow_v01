//Author: Marta Dubas, N9791701
using MvvmCross.Core.ViewModels;

namespace TestDemo.Core.ViewModels
{
    public class NewUserViewModel 
        : MvxViewModel
    {
        public IMvxCommand ChooseAvatarCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<ChooseAvatarViewModel>());
            }
        }

    }
}