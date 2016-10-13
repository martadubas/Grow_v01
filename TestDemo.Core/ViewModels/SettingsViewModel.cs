using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

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
    }
}
