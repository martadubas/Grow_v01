using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace TestDemo.Core.ViewModels
{
    class HelloNewUserViewModel
         : MvxViewModel
    {
        public IMvxCommand LevelViewViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<LevelViewModel>());
            }
        }
    }
}
