//author: Elvin Prananta
using MvvmCross.Core.ViewModels;
using TestDemo.Core.Models;
using System;
using System.Windows.Input;
using TestDemo.Core.Interfaces;
using TestDemo.Core.Database;
using System.Diagnostics;
using MvvmCross.Plugins.PictureChooser;
using MvvmCross.Platform;
using System.IO;

namespace TestDemo.Core.ViewModels
{

    public class GoalUpdateViewModel : MvxViewModel
    {
        private SelectedGoalDatabase selectedGoalDatabase;
        private GoalDatabase goalDatabase;
        private SelectedGoal selectedGoal;
        private UserDatabase _userDatabase = new UserDatabase();
        private User _user = new User();
        private byte[] _takenPhoto;

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
               
        public GoalUpdateViewModel(ISqlite sqlite)
        {
           
            this.selectedGoalDatabase = new SelectedGoalDatabase(sqlite);
            this.goalDatabase = new GoalDatabase(sqlite);

        }
        public void Init(int selectedGoalId)
        {
            
            try
            {
                selectedGoal = selectedGoalDatabase.GetSelectedGoal(selectedGoalId).Result;
                Goal thisGoal = goalDatabase.GetGoal(selectedGoal.GoalId).Result;
                selectedGoal.setGoal(thisGoal);//to update information of Goal object

            }
            catch (Exception e)
            {
                //possibly NullReferenceException
                Debug.WriteLine("exception: " + e.Message);
            }
        }
        public override void Start()
        {
            if(selectedGoal.Photo==null) TitleIfPhoto = selectedGoal.Goal.Title;
            Title = selectedGoal.Goal.Title;
            Description = selectedGoal.Goal.Description;
            Status = selectedGoal.Status;
            DateUpdated = selectedGoal.DateUpdated;
            TakenPhoto = selectedGoal.Photo;
            base.Start();
        }
        private async void TakePhoto()
        {
            var task = Mvx.Resolve<IMvxPictureChooserTask>();
            var stream = await task.TakePicture(1024, 90);
            if (stream != null)
            {
                Photo(stream);
            }

        }

        private void Photo(Stream pictureStream)
        {
            var memoryStream = new MemoryStream();
            pictureStream.CopyTo(memoryStream);
            TakenPhoto = memoryStream.ToArray(); //array of data that can be stored in db
            selectedGoal.Photo = TakenPhoto;
            selectedGoalDatabase.UpdateSelectedGoal(selectedGoal);

        }

        public byte[] TakenPhoto
        {
            get { return _takenPhoto; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _takenPhoto, value);
                }
            }
        }

        public ICommand TakePhotoCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    TakePhoto();
                });
                
            }
        }

        public IMvxCommand CompleteGoalCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    
                    selectedGoal.complete();
                    selectedGoalDatabase.UpdateSelectedGoal(selectedGoal);
                    _user = _userDatabase.GetUserById(1);

                    if (_user != null) _user.CompletedGoal = _user.CompletedGoal+10;
                    var x = _userDatabase.Update(_user);

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