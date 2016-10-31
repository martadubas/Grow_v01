//author: Elvin Prananta
using MvvmCross.Core.ViewModels;
using TestDemo.Core.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TestDemo.Core.Interfaces;
using TestDemo.Core.Database;
using System.Diagnostics;

namespace TestDemo.Core.ViewModels
{
    public class GoalDiaryViewModel
        : MvxViewModel
    {

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
            SelectedGoals = new ObservableCollection<SelectedGoal>() { };

            this.selectedGoalDatabase = new SelectedGoalDatabase(sqlite);
            this.goalDatabase = new GoalDatabase(sqlite);

            // only do this if doesn exist. will clear existing selected goals.
    
            loadSelectedGoalsFromDb();
            ViewSelectedGoalCommand = new MvxCommand<SelectedGoal>(selectedSelectedGoal => 
            {
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
                    ShowViewModel<GoalDiaryViewModel>();
                });
                
                
            }
        }

        public async void loadSelectedGoalsFromDb()
        {
            //Debug.WriteLine("###############  load diary from db");
            SelectedGoals.Clear();
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
                        selectedGoal.expire();
                        selectedGoalDatabase.UpdateSelectedGoal(selectedGoal);
                    }


                    SelectedGoals.Add(selectedGoal);
                }
                catch (Exception e)
                {
                    //possibly NullReferenceException
                    
                    Debug.WriteLine("###############  exception: "+e.Message);
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
            SelectedGoals.Add(newSGoal);

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
