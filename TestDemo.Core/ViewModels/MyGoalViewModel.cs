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
using TestDemo.Core.Converters;

namespace TestDemo.Core.ViewModels
{
    public class MyGoalViewModel
        : MvxViewModel
    {

        private SelectedGoalDatabase selectedGoalDatabase;
        private GoalDatabase goalDatabase;
        private readonly IDialogService dialog;

        private ObservableCollection<SelectedGoal> selectedGoals;

        public ObservableCollection<SelectedGoal> SelectedGoals
        {
            get { return selectedGoals; }
            set { SetProperty(ref selectedGoals, value); }
        }

        public ICommand ViewSelectedGoalCommand { get; private set; }

        public MyGoalViewModel(ISqlite sqlite, IDialogService dialog)
        {
            this.dialog = dialog;
            SelectedGoals = new ObservableCollection<SelectedGoal>() { };
            this.selectedGoalDatabase = new SelectedGoalDatabase(sqlite);
            this.goalDatabase = new GoalDatabase(sqlite);


            // only do this if doesn exist. will clear existing selected goals.
            //insertSampleSelectedGoalsToDbIfNotExist();
            loadSelectedGoalsFromDbToday();
            ViewSelectedGoalCommand = new MvxCommand<SelectedGoal>(selectedSelectedGoal =>
            {
                ShowViewModel<GoalUpdateViewModel>(new { selectedGoalId = selectedSelectedGoal.Id });
            }
            );
        }

        public async void loadSelectedGoalsFromDbToday()
        {
            //Debug.WriteLine("###############  load goal today from db");
            SelectedGoals.Clear();
            var selectedGoalsInDb = selectedGoalDatabase.GetSelectedGoalsToday().Result;

            foreach (var selectedGoal in selectedGoalsInDb)
            {
                if (!selectedGoal.Status.Equals("DELETED")) //if goal is deleted, dont display it
                {
                    try
                    {
                        Goal thisGoal = goalDatabase.GetGoal(selectedGoal.GoalId).Result;
                        selectedGoal.setGoal(thisGoal);//to update information of Goal object
                        SelectedGoals.Add(selectedGoal);
                    }
                    catch (Exception e)
                    {
                        //possibly NullReferenceException
                        Debug.WriteLine("###############  exception: " + e.Message);
                    }
                }

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
                return new MvxCommand(() => dialog.Show("Not available yet", "This functionality will come in the next version", "OK"));
            }

        }
        public async void clearSelectedGoalDb()
        {
            //Debug.WriteLine("###############  clear all selected goals");

            await selectedGoalDatabase.DeleteAll();
        }
    }
}
