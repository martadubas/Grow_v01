﻿//Author: Zeyuan Liu, N9557296
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace TestDemo.Core.ViewModels
{
    class LevelViewModel
         : MvxViewModel
    {
        public IMvxCommand ChooseTasksViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<ChooseTasksViewModel>());
            }
        }
    }
}