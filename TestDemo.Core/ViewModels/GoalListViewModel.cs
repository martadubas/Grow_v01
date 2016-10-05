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

        public ICommand SelectGoalCommand { get; private set; }
        public GoalListViewModel()
        {

            Goals = getSampleGoals();
        
            SelectGoalCommand = new MvxCommand<Goal>(selectedGoal => ShowViewModel<GoalDetailViewModel>(selectedGoal));
            
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


            Goals = new ObservableCollection<Goal>() { };

            Goals.Add(new Goal("Goal 1", "Description 1", "food"));
            Goals.Add(new Goal("Goal 2", "Description 2", "sport"));
            Goals.Add(new Goal("Goal 3", "Description 3", "social"));
            Goals.Add(new Goal("Goal 4", "Description 4", "food"));
            Goals.Add(new Goal("Goal 5", "Description 5", "sport"));
            Goals.Add(new Goal("Goal 6", "Description 6", "social"));

            return Goals;

        }
    }
}
