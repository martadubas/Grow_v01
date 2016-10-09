using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MvvmCross.Core.ViewModels;
using TestDemo.Core.Models;
using TestDemo.Core.Database;
using TestDemo.Core.Interfaces;
//using TestDemo.Core.Services;

namespace TestDemo.Core.ViewModels
{

    public class GoalDetailViewModel : MvxViewModel
    {
        private Goal goal;
        private SelectedGoalDatabase selectedGoalDatabase;

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        //private MyDrawable _myDrawable;
        //public string MyDrawable
        //{
        //    get { return _myDrawable; }
        //    set
        //    {
        //        _myDrawable = value;
        //        RaisePropertyChanged(() => MyDrawable);
        //    }
        //}
        public GoalDetailViewModel(ISqlite sqlite)
        {
            this.selectedGoalDatabase = new SelectedGoalDatabase(sqlite);
        }
        public void Init(Goal goal)
        {
            this.goal = goal;

        }
        public override void Start()
        {
            Title = goal.Title;
            Description = goal.Description;
            base.Start();
        }


        public IMvxCommand GoalListViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<GoalListViewModel>());
            }
        }
        public IMvxCommand SelectGoalCommand
        {
            get
            {
                insertSelectedGoals(new SelectedGoal(goal));
                return new MvxCommand(() => ShowViewModel<GoalDiaryViewModel>());
            }
        }
        public async void insertSelectedGoals(SelectedGoal selectedGoal)
        {
            await selectedGoalDatabase.InsertSelectedGoal(selectedGoal);

            //Close(this);

        }

    }
}