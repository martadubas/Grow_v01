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

            // only do this for one time, it will clear existing database. beware, may clear dependencies
            //insertSampleGoalsToDb(getSampleGoals());
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
            foreach (var goal in goalsInDb)
            {
                Debug.WriteLine("##### forEach goal : "+goal.Id);
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
            Goals.Add(new Goal("Goal 1", "Description 1", "food"));
            Goals.Add(new Goal("Goal 2", "Description 2", "sport"));
            Goals.Add(new Goal("Goal 3", "Description 3", "social"));
            Goals.Add(new Goal("Goal 4", "Description 4", "food"));
            Goals.Add(new Goal("Goal 5", "Description 5", "sport"));
            Goals.Add(new Goal("Goal 6", "Description 6", "social"));

            return Goals;

        }

        public async void insertSampleGoalsToDb(ObservableCollection<Goal> goals)
        {

            await goalDatabase.DeleteAll();
            foreach (var goal in goals)
            {
                await goalDatabase.InsertGoal(goal);
            }
            Close(this);

        }
    }
}
