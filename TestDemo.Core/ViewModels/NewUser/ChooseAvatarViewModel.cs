using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;


namespace TestDemo.Core.ViewModels

{
    public class ChooseAvatarViewModel
         : MvxViewModel
    {
        public IMvxCommand HelloNewUserViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<HelloNewUserViewModel>());
            }
        }

        public void SetAvatar(int position)
        {
            //switch (position)
            //{
            //    case 0:
            //        break;
            //    case 1:
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
