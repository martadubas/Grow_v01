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

    public class GoalUpdateViewModel : MvxViewModel
    {
        private SelectedGoalDatabase selectedGoalDatabase;
        private GoalDatabase goalDatabase;
        private SelectedGoal selectedGoal;

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }

        private DateTime dateUpdated;
        public DateTime DateUpdated
        {
            get { return dateUpdated; }
            set { SetProperty(ref dateUpdated, value); }
        }

        //private MyDrawable _myDrawable;
        //public string MyDrawable
        //{
        //    get { return _myDrawable; }
        //    set
        //    {
        //        _myDrawable = value;
        //        RaisePropertyChanged(() => MyDrawable);
        //    }
        //}
        public GoalUpdateViewModel(ISqlite sqlite)
        {
            //Debug.WriteLine("###############  initialize sqlite");
            this.selectedGoalDatabase = new SelectedGoalDatabase(sqlite);
            this.goalDatabase = new GoalDatabase(sqlite);


        }
        public void Init(int selectedGoalId)
        {
            //Debug.WriteLine("###############  init goal update");
            Debug.WriteLine("###############  selected goal Id= " + selectedGoalId);
            try
            {
                selectedGoal = selectedGoalDatabase.GetSelectedGoal(selectedGoalId).Result;
                Goal thisGoal = goalDatabase.GetGoal(selectedGoal.GoalId).Result;
                selectedGoal.setGoal(thisGoal);//to update information of Goal object
                //Debug.WriteLine("############### added Goal " + thisGoal.Title +" "+thisGoal.Title);

            }
            catch (Exception e)
            {
                //possibly NullReferenceException
                Debug.WriteLine("###############  exception: " + e.Message);
            }
        }
        public override void Start()
        {
            Debug.WriteLine("###############  Goal update start");

            Title = selectedGoal.Goal.Title;
            Description = selectedGoal.Goal.Description;
            Status = selectedGoal.Status;
            DateUpdated = selectedGoal.DateUpdated;
            base.Start();
        }

        public IMvxCommand CompleteGoalCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    //Debug.WriteLine("###############  select currentGoal = " + goal + " goal Id= " + goal.Id);
                    selectedGoal.complete();
                    //Debug.WriteLine("###############  currentGoal = " + selectedGoal.Status);
                    selectedGoalDatabase.UpdateSelectedGoal(selectedGoal);
                    ShowViewModel<MyGoalViewModel>();
                });
            }
        }
        public IMvxCommand DeleteGoalCommand
        {
            get
            {

                return new MvxCommand(() =>
                {
                    //Debug.WriteLine("###############  select currentGoal = " + goal + " goal Id= " + goal.Id);
                    selectedGoal.delete();
                    selectedGoalDatabase.UpdateSelectedGoal(selectedGoal);
                    ShowViewModel<MyGoalViewModel>();
                });
            }
        }

        public IMvxCommand GoalDiaryViewCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    ShowViewModel<GoalDiaryViewModel>();
                });
            }
        }
        public IMvxCommand HomeViewCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    ShowViewModel<HomeViewModel>();
                });
            }
        }
    }
}