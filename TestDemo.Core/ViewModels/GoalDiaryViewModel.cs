using MvvmCross.Core.ViewModels;
using TestDemo.Core.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.Generic;
using TestDemo.Core.Interfaces;
using TestDemo.Core.Database;
using System.Diagnostics;

namespace TestDemo.Core.ViewModels
{
    public class GoalDiaryViewModel
        : MvxViewModel
    {

        //private readonly IDialogService dialog;
        private SelectedGoalDatabase selectedGoalDatabase;
        private GoalDatabase goalDatabase;


        private ObservableCollection<SelectedGoal> selectedGoals;

        public ObservableCollection<SelectedGoal> SelectedGoals
        {
            get { return selectedGoals; }
            set { SetProperty(ref selectedGoals, value); }
        }


        public ICommand ViewSelectedGoalCommand { get; private set; }

        public GoalDiaryViewModel(ISqlite sqlite)
        {
            Debug.WriteLine("###############  new GoalDiary");
            SelectedGoals = new ObservableCollection<SelectedGoal>() { };

            //this.selectedGoalDatabase = new SelectedGoalDatabase(sqlite);
            //SelectedGoals = getSampleSelectedGoals();

            //ViewSelectedGoalCommand = new MvxCommand<SelectedGoal>(selectedSelectedGoal => ShowViewModel<SelectedGoalDetailViewModel>(selectedSelectedGoal));

            this.selectedGoalDatabase = new SelectedGoalDatabase(sqlite);
            this.goalDatabase = new GoalDatabase(sqlite);


            // only do this if doesn exist. will clear existing selected goals.
            //insertSampleSelectedGoalsToDbIfNotExist();
            loadSelectedGoalsFromDb();
            ViewSelectedGoalCommand = new MvxCommand<SelectedGoal>(selectedSelectedGoal => ShowViewModel<GoalDetailViewModel>(selectedSelectedGoal));

        }

        public async void loadSelectedGoalsFromDb()
        {
            Debug.WriteLine("###############  load diary from db");
            SelectedGoals.Clear();
            //var selectedGoalsInDb = await selectedGoalDatabase.GetSelectedGoals();
            Debug.WriteLine("###############  get selected goals from db");
            var selectedGoalsInDb = selectedGoalDatabase.GetSelectedGoals();

            foreach (var selectedGoal in selectedGoalsInDb)
            {
                Debug.WriteLine("###############  foreach: selected goal id = "+selectedGoal.Id+", "+selectedGoal.GoalId);
                try
                {
                    Goal thisGoal = goalDatabase.GetGoal(selectedGoal.GoalId).Result;
                    selectedGoal.setGoal(thisGoal);//to update information of Goal object
                    SelectedGoals.Add(selectedGoal);
                    Debug.WriteLine("############### added Goal " + thisGoal.Title +" "+thisGoal.Title);

                }
                catch (Exception e)
                {
                    //possibly NullReferenceException
                    Debug.WriteLine("###############  exception: "+e.Message);

                }
                
            }
        }

        public async void insertSampleSelectedGoalsToDbIfNotExist()
        {
            clearSelectedGoalDb();
            Debug.WriteLine("###############  insert sample diary");

            Goal goal = goalDatabase.GetTheFirstGoal(); //this works
            if (goal == null)
            {
                //in case of empty goalDb
                goal = new Goal("Title", "Desc", "Cat");
            }


            SelectedGoals.Add(new SelectedGoal(goal));

           // await selectedGoalDatabase.DeleteAll();
            foreach (var selectedGoal in SelectedGoals)
            {
                await selectedGoalDatabase.InsertSelectedGoal(selectedGoal);
            }
            Close(this);
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
        public async void clearSelectedGoalDb()
        {
            Debug.WriteLine("###############  clear all selected goals");

            await selectedGoalDatabase.DeleteAll();
        }
    }
}
