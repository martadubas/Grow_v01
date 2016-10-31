using MvvmCross.Platform.IoC;
using TestDemo.Core.Database;
using TestDemo.Core.Models;

namespace TestDemo.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        private UserDatabase _userDatabase = new UserDatabase();
        private SelectedGoalDatabase _selectedGoalDatabase = new SelectedGoalDatabase();
        private GoalDatabase _goalDatabase = new GoalDatabase();


        private User _user = new User();
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            
            if (_userDatabase.GetUserById(1)==null)
            {
                RegisterAppStart<ViewModels.InfoNewUserViewModel>();
            }
            else
            {
                RegisterAppStart<ViewModels.JourneyViewModel>();
            }

        }

         }
}
