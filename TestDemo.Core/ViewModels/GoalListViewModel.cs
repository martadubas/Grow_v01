using MvvmCross.Core.ViewModels;
using TestDemo.Core.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.Generic;

namespace TestDemo.Core.ViewModels
{
    public class GoalListViewModel
        : MvxViewModel
    {

        private ObservableCollection<Goal> goals;
        public ObservableCollection<Goal> Goals
        {
            get { return goals; }
            set { SetProperty(ref goals, value); }
        }
        private string goalDescription;
        public string GoalDescription
        {
            get { return goalDescription; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref goalDescription, value);
                }
            }
        }


        public ICommand SelectGoalCommand { get; private set; }
        public GoalListViewModel()
        {
            List<string> goallist = new List<string>
            { 
                "Goal 1", "Goal 2", "Goal 3","Goal 4","Goal 5","Goal 1", "Goal 2", "Goal 3","Goal 4","Goal 5","Goal 1", "Goal 2", "Goal 3","Goal 4","Goal 5"
            };

            Goals = new ObservableCollection<Goal>()
        {
            
        };
            foreach(string goal in goallist ){
                Goals.Add(new Models.Goal(goal));
            }


            SelectGoalCommand = new MvxCommand<Goal>(goal =>
            {
                //GoalDescription = goal.GoalDescription;
                //do nothing for now. 
            });
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
                //Context context = getApplicationContext();
                //string text = "Share on Facebook!";
                //int duration = Toast.LENGTH_SHORT;

                //Toast toast = Toast.makeText(context, text, duration);
                //toast.show();
                return new MvxCommand(() =>
                {
                    //RaisePropertyChanged(() => Goals);
                    
                });
            }

        }
    }
}
