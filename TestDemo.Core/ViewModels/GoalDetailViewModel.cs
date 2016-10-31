//author: Elvin Prananta
using MvvmCross.Core.ViewModels;
using TestDemo.Core.Models;
using TestDemo.Core.Database;
using TestDemo.Core.Interfaces;

namespace TestDemo.Core.ViewModels
{

    public class GoalDetailViewModel : MvxViewModel
    {
        private Goal goal;
        private SelectedGoalDatabase selectedGoalDatabase;
       
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string titleIfPhoto;
        public string TitleIfPhoto
        {
            get { return titleIfPhoto; }
            set { SetProperty(ref titleIfPhoto, value); }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }
        public GoalDetailViewModel(ISqlite sqlite, IDialogService dialog)
        {
            //Debug.WriteLine("###############  initialize sqlite");
            this.selectedGoalDatabase = new SelectedGoalDatabase(sqlite);
           

        }
        public void Init(Goal goal)
        {
            this.goal = goal;

        }
        public override void Start()
        {
            Title = goal.Title;
            TitleIfPhoto = goal.Title;
            Description = goal.Description;
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

                return new MvxCommand(() => 
                {
                    if (goal.Title.Contains("STARTED")||goal.Title.Contains("COMPLETED")) 
                    {
                        //show toast in view
                    }else
                    {
                        insertSelectedGoal(new SelectedGoal(goal));
                        ShowViewModel<GoalListViewModel>();
                    }
                    
                });
               
            }
        }
        public async void insertSelectedGoal(SelectedGoal selectedGoal)
        {
            //Debug.WriteLine("###############  insert goal: "+selectedGoal.toString());

            await selectedGoalDatabase.InsertSelectedGoal(selectedGoal);

            //Debug.WriteLine("###############  after insert goal");

            //Close(this);

        }

    }
}