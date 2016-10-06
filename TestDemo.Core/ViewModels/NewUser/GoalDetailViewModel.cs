using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MvvmCross.Core.ViewModels;
using TestDemo.Core.Models;


namespace TestDemo.Core.ViewModels
{
    public class GoalDetailViewModel : MvxViewModel
    {
        private Goal goal;

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
        public void Init(Goal goal)
        {
            this.goal = goal;

        }
        public override void Start()
        {
            Title = goal.Title;
            Description = goal.Description;
            //MyDrawable = goal.Title.Trim();
            base.Start();
        }


        public IMvxCommand GoalListViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<GoalListViewModel>());
            }
        }
        public IMvxCommand SelectGoalCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<GoalListViewModel>());
            }
        }


    }
}