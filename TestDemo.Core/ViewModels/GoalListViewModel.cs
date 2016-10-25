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
using System.Threading.Tasks;

namespace TestDemo.Core.ViewModels
{
    public class GoalListViewModel
        : MvxViewModel
    {

        //private readonly IDialogService dialog;
        private GoalDatabase goalDatabase;
        private SelectedGoalDatabase selectedGoalDatabase;
        private readonly IDialogService dialog;



        private ObservableCollection<Goal> goals;

        public ObservableCollection<Goal> Goals
        {
            get { return goals; }
            set { SetProperty(ref goals, value); }
        }


        public ICommand SelectGoalCommand { get; private set; }


        public GoalListViewModel(ISqlite sqlite, IDialogService dialog)
        {
            this.dialog = dialog;
            //this.goalDatabase = new GoalDatabase(sqlite);
            Goals = new ObservableCollection<Goal>() { };
            //Goals = getSampleGoals();

            //SelectGoalCommand = new MvxCommand<Goal>(selectedGoal => ShowViewModel<GoalDetailViewModel>(selectedGoal));

            this.goalDatabase = new GoalDatabase(sqlite);
            this.selectedGoalDatabase = new SelectedGoalDatabase(sqlite);


            // only do this for one time, it will clear existing database. beware, may clear dependencies
            insertSampleGoalsToDbIfNotExist();
            loadGoalsFromDb();
            
            SelectGoalCommand = new MvxCommand<Goal>(selectedGoal => {
                //if (selectedGoal.Title.Contains("STARTED")|| selectedGoal.Title.Contains("COMPLETED"))
                //{
                //    bool found = false;
                //    var selectedGoalsToday = getSelectedGoalsToday().Result;


                //    foreach (SelectedGoal sg in selectedGoalsToday)
                //    {
                //        if (sg.GoalId == selectedGoal.Id)
                //        {
                //            found = true;
                //            sg.Goal = selectedGoal;
                //            ShowViewModel<GoalUpdateViewModel>(sg);
                //        }
                //    }
                //    if (!found)
                //    {
                //        ShowViewModel<GoalDetailViewModel>(selectedGoal);

                //    }


                //}
                //else
                //{
                    ShowViewModel<GoalDetailViewModel>(selectedGoal);
                //}
                    }
            
            );

        }

        public void OnResume()
        {
            //loadGoalsFromDb();
        }

        public async void loadGoalsFromDb()
        {
            Goals.Clear();
            var goalsInDb = await goalDatabase.GetGoals();
            var selectedGoalsToday = getSelectedGoalsToday().Result;


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

        public async Task<List<SelectedGoal>> getSelectedGoalsToday()
        {
            var selectedGoalsToday = await selectedGoalDatabase.GetSelectedGoalsToday();
            return selectedGoalsToday;
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
                await goalDatabase.InsertGoal(new Goal(1, "Go for a walk", "Take on your shoes and enjoy the fresh air outside!", "sport"));
                await goalDatabase.InsertGoal(new Goal(2, "Streching", "After your shower, when muscles are relaxed, do some easy stretching excercises.", "sport"));
                await goalDatabase.InsertGoal(new Goal(3, "Find a buddy", "Find a person you could go for a walk regulary. You can motivate each other!", "social"));
                await goalDatabase.InsertGoal(new Goal(4, "Meetup", "Call a friend and go out with her/him. See a movie or have a dinner out", "social"));
                await goalDatabase.InsertGoal(new Goal(5, "Keep water close to you", "Keep a full water bottle on your desk and drink water throughout the day.", "food"));
                await goalDatabase.InsertGoal(new Goal(6, "Walk a bit more", "Are you driving to the supermarket to do some shopping? Park your car a bit further away so you can walk a bit!", "food"));
                await goalDatabase.InsertGoal(new Goal(7, "Inner peace", "Close your eyes, sit on the floor and try to focus on your breathing for 5 min", "relax"));
                await goalDatabase.InsertGoal(new Goal(8, "Eat a leaf", "Increase dark green leafy vegetables in your diet like kale, spinach, swiss chard, and mustardgreens.", "food"));
                await goalDatabase.InsertGoal(new Goal(9, "Go greener", "Add one additional serving of vegetables to one of your daily meals.", "food"));
                await goalDatabase.InsertGoal(new Goal(10, "Tea time", "Drink a cup of green tea. Tasty!", "food"));
                await goalDatabase.InsertGoal(new Goal(11, "Active watching", "Walk or jogg in place while watching tv. Make as many breakes as you wish.", "social"));
                await goalDatabase.InsertGoal(new Goal(12, "Fresh start", "Drink a glass of water - first thing in the morning.", "food"));

            }


            Close(this);

        }
    }
}
