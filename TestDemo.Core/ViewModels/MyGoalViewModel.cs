using MvvmCross.Core.ViewModels;
using TestDemo.Core.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.Generic;
using TestDemo.Core.Interfaces;
using TestDemo.Core.Database;


namespace TestDemo.Core.ViewModels
{
    public class MyGoalViewModel
        : MvxViewModel
    {

       // private readonly IDialogService dialog;
        private SelectedGoalDatabase selectedGoalDatabase;
        private GoalDatabase goalDatabase;


        private ObservableCollection<SelectedGoal> selectedGoals;

        public ObservableCollection<SelectedGoal> SelectedGoals
        {
            get { return selectedGoals; }
            set { SetProperty(ref selectedGoals, value); }
        }


        public ICommand ViewSelectedGoalCommand { get; private set; }
        

        public MyGoalViewModel(ISqlite sqlite)
        {
            //this.selectedGoalDatabase = new SelectedGoalDatabase(sqlite);
            //SelectedGoals = new ObservableCollection<SelectedGoal>();
            //SelectedGoals = getSampleSelectedGoals();

            //ViewSelectedGoalCommand = new MvxCommand<SelectedGoal>(selectedSelectedGoal => ShowViewModel<SelectedGoalDetailViewModel>(selectedSelectedGoal));

            this.selectedGoalDatabase = new SelectedGoalDatabase(sqlite);
            this.goalDatabase = new GoalDatabase(sqlite);


            // only do this if doesn exist
            insertSampleSelectedGoalsToDb();
            loadSelectedGoalsFromDb();
            ViewSelectedGoalCommand = new MvxCommand<SelectedGoal>(selectedSelectedGoal => ShowViewModel<GoalDetailViewModel>(selectedSelectedGoal));

        }

        //public void OnResume()
        //{
        //    loadSelectedGoals();
        //}

        public async void loadSelectedGoalsFromDb()
        {
            //SelectedGoals.Clear();
            //var selectedGoalsInDb = await selectedGoalDatabase.GetSelectedGoals();
            var selectedGoalsInDb = selectedGoalDatabase.GetSelectedGoals();

            //TODO the goal is still not shown. find out how to retrived child element or foreignkey
            foreach (var selectedGoal in selectedGoalsInDb)
            {
                Goal thisGoal = goalDatabase.GetGoal(selectedGoal.GoalId).Result;
                if (thisGoal == null)
                {
                    thisGoal = new Goal("null goal retrieved", "ll", "ff");
                }
                else
                {
                    thisGoal = new Goal("not null", "asdasd", "asdasd");
                }
                selectedGoal.setGoal(thisGoal);
                RaisePropertyChanged();

                SelectedGoals.Add(selectedGoal);
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

        public async void insertSampleSelectedGoalsToDb()
        {
            Goal goal = goalDatabase.GetTheFirstGoal(); //this works

            SelectedGoals = new ObservableCollection<SelectedGoal>() { };

            SelectedGoals.Add(new SelectedGoal(goal));

            await selectedGoalDatabase.DeleteAll();
            foreach (var selectedGoal in SelectedGoals)
            {
                await selectedGoalDatabase.InsertSelectedGoal(selectedGoal);
            }
            Close(this);
            //}
            //else
            //{
            //    if (await dialog.Show("This location has already been added", "Location Exists", "Keep Searching", "Go Back"))
            //    {
            //        SearchTerm = string.Empty;
            //        Locations.Clear();
            //    }
            //    else
            //    {
            //        Close(this);
            //    }
            //}
        }
    }
}
