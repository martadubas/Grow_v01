//Author: Marta Dubas, N9791701
using MvvmCross.Core.ViewModels;

namespace TestDemo.Core.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
    {
        //private string _hello = "Hello MvvmCross";
        //public string Hello
        //{
        //    get { return _hello; }
        //    set { SetProperty(ref _hello, value); }
        //}
        private string _name = "Hello MvvmCross";
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != null && value != _name)
                {
                    _name = value;
                    RaisePropertyChanged(() => Name);
                }
            }
        }
        
    }
}
