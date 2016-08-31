//Author: Elvin Prananta, N9806482
using MvvmCross.Core.ViewModels;

namespace TestDemo.Core.ViewModels
{
    public class HomeViewModel 
        : MvxViewModel
    {
        //private string _hello = "Hello MvvmCross";
        //public string Hello
        //{
        //    get { return _hello; }
        //    set { SetProperty(ref _hello, value); }
        //}


        public IMvxCommand StartFirstViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<FirstViewModel>());
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
