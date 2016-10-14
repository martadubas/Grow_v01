using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MvvmCross.Core.ViewModels;
using TestDemo.Core.Models;
using TestDemo.Core.Database;
using TestDemo.Core.Interfaces;
using System.Diagnostics;

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
            //Debug.WriteLine("###############  initialize sqlite");
            this.selectedGoalDatabase = new SelectedGoalDatabase(sqlite);

        }
        public void Init(Goal goal)
        {
            //Debug.WriteLine("###############  init goal");

            this.goal = goal;

        }
        public override void Start()
        {
            //Debug.WriteLine("###############  start");

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

                return new MvxCommand(() => 
                {
                    //Debug.WriteLine("###############  select currentGoal = " + goal + " goal Id= " + goal.Id);
                    if (goal.Title.Contains("STARTED")||goal.Title.Contains("COMPLETED")) 
                    {
                        //show toast in view
                    }else
                    {
                        insertSelectedGoal(new SelectedGoal(goal));
                        ShowViewModel<MyGoalViewModel>();
                    }
                    
                });
                
                
            }
        }
        public async void insertSelectedGoal(SelectedGoal selectedGoal)
        {
            //Debug.WriteLine("###############  insert goals");

            await selectedGoalDatabase.InsertSelectedGoal(selectedGoal);
            Debug.WriteLine("###############  after insert goal");

            //Close(this);

        }

    }
}