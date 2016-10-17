using MvvmCross.Core.ViewModels;
using TestDemo.Core.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.Generic;
using TestDemo.Core.Database;
using TestDemo.Core.Interfaces;
using System.Diagnostics;

namespace TestDemo.Core.ViewModels
{
    public class GoalListViewModel
        : MvxViewModel
    {

        //private readonly IDialogService dialog;
        private GoalDatabase goalDatabase;
        private SelectedGoalDatabase selectedGoalDatabase;


        private ObservableCollection<Goal> goals;

        public ObservableCollection<Goal> Goals
        {
            get { return goals; }
            set { SetProperty(ref goals, value); }
        }


        public ICommand SelectGoalCommand { get; private set; }


        public GoalListViewModel(ISqlite sqlite)
        {
            //this.goalDatabase = new GoalDatabase(sqlite);
            Goals = new ObservableCollection<Goal>() { };
            //Goals = getSampleGoals();

            //SelectGoalCommand = new MvxCommand<Goal>(selectedGoal => ShowViewModel<GoalDetailViewModel>(selectedGoal));

            this.goalDatabase = new GoalDatabase(sqlite);
            this.selectedGoalDatabase = new SelectedGoalDatabase(sqlite);


            // only do this for one time, it will clear existing database. beware, may clear dependencies
            insertSampleGoalsToDbIfNotExist();
            loadGoalsFromDb();
            
            SelectGoalCommand = new MvxCommand<Goal>(selectedGoal => ShowViewModel<GoalDetailViewModel>(selectedGoal));

        }

        public void OnResume()
        {
            //loadGoalsFromDb();
        }

        public async void loadGoalsFromDb()
        {
            Goals.Clear();
            var goalsInDb = await goalDatabase.GetGoals();
            var selectedGoalsToday = await selectedGoalDatabase.GetSelectedGoalsToday();


            foreach (var goal in goalsInDb)
            {
                foreach(var selectedGoal in selectedGoalsToday)
                {
                    //Debug.WriteLine("############# selected.goal.id " + selectedGoal.GoalId + " goal.id " + goal.Id);

                    if (selectedGoal.GoalId == goal.Id)
                    {

                        goal.updateTitle(selectedGoal.Status);
                        //Debug.WriteLine("############# goal title after update "+goal.Title);

                        break;
                    }
                }
                Goals.Add(goal);
            }
        }
        public IMvxCommand HomeViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<HomeViewModel>());
            }
        }
        public IMvxCommand ShareOnFacebookCommand
        {
            get
            {
                return null;
            }

        }
        private ObservableCollection<Goal> getSampleGoals()
        {
            
       
            return Goals;

        }

        public async void insertSampleGoalsToDbIfNotExist()
        {

            //await goalDatabase.DeleteAll();
            Goal goal = goalDatabase.GetTheFirstGoal(); 
            if (goal == null)
            {
                //in case of empty goalDb
                //await goalDatabase.InsertGoal(new Goal("Goal 1", "Description 1", "food"));
                //await goalDatabase.InsertGoal(new Goal("Goal 2", "Description 2", "sport"));
                //await goalDatabase.InsertGoal(new Goal("Goal 3", "Description 3", "social"));
                //await goalDatabase.InsertGoal(new Goal("Goal 4", "Description 4", "sport"));
                //await goalDatabase.InsertGoal(new Goal("Goal 5", "Description 5", "social"));
                //await goalDatabase.InsertGoal(new Goal("Goal 6", "Description 6", "food"));

                //in case of empty goalDb
                await goalDatabase.InsertGoal(new Goal(1, "Goal 1", "Description 1", "food"));
                await goalDatabase.InsertGoal(new Goal(2, "Goal 2", "Description 2", "sport"));
                await goalDatabase.InsertGoal(new Goal(3, "Goal 3", "Description 3", "social"));
                await goalDatabase.InsertGoal(new Goal(4, "Goal 4", "Description 4", "sport"));
                await goalDatabase.InsertGoal(new Goal(5, "Goal 5", "Description 5", "social"));
                await goalDatabase.InsertGoal(new Goal(6, "Goal 6", "Description 6", "food"));

            }


            Close(this);

        }
    }
}
