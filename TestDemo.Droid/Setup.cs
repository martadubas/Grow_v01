using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using TestDemo.Core.Interfaces;
using TestDemo.Core.Database;
using TestDemo.Droid.Database;
using MvvmCross.Platform;
using TestDemo.Droid.Services;

namespace TestDemo.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new TestDemo.Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            Mvx.LazyConstructAndRegisterSingleton<ISqlite, SqliteDroid>();
            Mvx.LazyConstructAndRegisterSingleton<IDialogService, DialogService>();
            //Mvx.LazyConstructAndRegisterSingleton<IUserDatabase, UserDatabase>();
            base.InitializeFirstChance();
        }
    }
}
