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
    public class GoalDiaryViewModel
        : MvxViewModel
    {

        //private readonly IDialogService dialog;
        private SelectedGoalDatabase selectedGoalDatabase;
        private GoalDatabase goalDatabase;
        private IDialogService dialog;

        private ObservableCollection<SelectedGoal> selectedGoals;

        public ObservableCollection<SelectedGoal> SelectedGoals
        {
            get { return selectedGoals; }
            set { SetProperty(ref selectedGoals, value); }
        }

        public ICommand ViewSelectedGoalCommand { get; private set; }

        public GoalDiaryViewModel(ISqlite sqlite, IDialogService dialog)
        {
            this.dialog = dialog;
            //Debug.WriteLine("###############  new GoalDiary");
            SelectedGoals = new ObservableCollection<SelectedGoal>() { };

            //this.selectedGoalDatabase = new SelectedGoalDatabase(sqlite);
            //SelectedGoals = getSampleSelectedGoals();

            //ViewSelectedGoalCommand = new MvxCommand<SelectedGoal>(selectedSelectedGoal => ShowViewModel<SelectedGoalDetailViewModel>(selectedSelectedGoal));

            this.selectedGoalDatabase = new SelectedGoalDatabase(sqlite);
            this.goalDatabase = new GoalDatabase(sqlite);


            // only do this if doesn exist. will clear existing selected goals.
            //insertSampleSelectedGoalsToDbForTesting();
            //clearSelectedGoalDb();
            loadSelectedGoalsFromDb();
            ViewSelectedGoalCommand = new MvxCommand<SelectedGoal>(selectedSelectedGoal => 
            {
                //Debug.WriteLine("###############  selected goal = " + selectedSelectedGoal.Id + " goal Id= " + selectedSelectedGoal.Goal.Id);
                ShowViewModel<GoalUpdateViewModel>(new { selectedGoalId = selectedSelectedGoal.Id });
                }
            );
        }

        public IMvxCommand ShowDialogCommand
        {
            get
            {
                return new MvxCommand(() => 
                {
                    //Debug.WriteLine("###############  select currentGoal = " + goal + " goal Id= " + goal.Id);
                    //insertSelectedGoal(new SelectedGoal(goal));
                    ShowViewModel<GoalDiaryViewModel>();
                });
                
                
            }
        }

        public async void loadSelectedGoalsFromDb()
        {
            //Debug.WriteLine("###############  load diary from db");
            SelectedGoals.Clear();
            //var selectedGoalsInDb = await selectedGoalDatabase.GetSelectedGoals();
            //Debug.WriteLine("###############  get selected goals from db");
            var selectedGoalsInDb = selectedGoalDatabase.GetSelectedGoals();

            foreach (var selectedGoal in selectedGoalsInDb)
            {
                
                try
                {
                    //Debug.WriteLine("###############  details = " + selectedGoal.toString());

                    Goal thisGoal = goalDatabase.GetGoal(selectedGoal.GoalId).Result;
                    if (thisGoal == null)
                    {
                        thisGoal = new Goal(0,"Goal not found", "", "");
                    }
                    selectedGoal.setGoal(thisGoal);//to update information of Goal object

                    if (selectedGoal.Status.Equals("STARTED") && selectedGoal.DateUpdated.Date < DateTime.Today.ToLocalTime().Date)
                    {
                        //Debug.WriteLine("###############  goal seems to be expired. " + selectedGoal.toString());
                        //Debug.WriteLine("######  created: " + selectedGoal.DateCreated);
                        //Debug.WriteLine("#####  updated: " + selectedGoal.DateUpdated);
                        //Debug.WriteLine("########  DateTime.Today.Date: " + DateTime.Today.Date);
                        //Debug.WriteLine("#######  selectedGoal.DateUpdated.Date: " + selectedGoal.DateCreated.Date);



                        selectedGoal.expire();

                        //Debug.WriteLine("--------   after expired");
                        //Debug.WriteLine("########  DateTime.Today.Date: " + DateTime.Today.Date);
                        //Debug.WriteLine("#######  selectedGoal.DateUpdated.Date: " + selectedGoal.DateCreated.Date);
                        selectedGoalDatabase.UpdateSelectedGoal(selectedGoal);
                        //Debug.WriteLine("###############  expired = " + selectedGoal.toString());
                    }


                    SelectedGoals.Add(selectedGoal);
                    //Debug.WriteLine("############### added Goal " + thisGoal.Title +" "+thisGoal.Title);
                }
                catch (Exception e)
                {
                    //possibly NullReferenceException
                    
                    Debug.WriteLine("###############  exception: "+e.Message);
                    //selectedGoal.GoalId = 1;
                    await selectedGoalDatabase.DeleteSelectedGoal(selectedGoal.Id);
                }
                
            }
        }

        public async void insertSampleSelectedGoalsToDbForTesting()
        {
            clearSelectedGoalDb();
            Debug.WriteLine("###############  insert sample diary");

            Goal goal = goalDatabase.GetTheFirstGoal(); //this works
            if (goal == null)
            {
                //in case of empty goalDb
                goal = new Goal(0,"Sample Title", "Desc", "Cat");
            }
            SelectedGoal newSGoal = new SelectedGoal(goal);
            //DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7, 123);
            //newSGoal.DateCreated = new DateTime(2008, 3, 9, 16, 5, 7, 123);


            SelectedGoals.Add(newSGoal);

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
                return new MvxCommand(() => dialog.Show("Not available yet", "This functionality will come in the next version", "OK"));
            }

        }
        public async void clearSelectedGoalDb()
        {
            Debug.WriteLine("###############  clear all selected goals");

            await selectedGoalDatabase.DeleteAll();
        }
    }
}
