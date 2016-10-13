using MvvmCross.Platform.IoC;
using TestDemo.Core.Database;
using TestDemo.Core.Models;

namespace TestDemo.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        private UserDatabase _userDatabase = new UserDatabase();
        private User _user = new User();
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
           // _userDatabase.DeleteAll();
            //RegisterAppStart<ViewModels.JourneyViewModel>();
            if (_userDatabase.GetUserById(1)==null)
            {
                RegisterAppStart<ViewModels.InfoNewUserViewModel>();
            }
            else
            {
                RegisterAppStart<ViewModels.HomeViewModel>();
            }
            

            //RegisterAppStart<ViewModels.GoalListViewModel>();
            //RegisterAppStart<ViewModels.GoalDiaryViewModel>();
        }


    }
}
