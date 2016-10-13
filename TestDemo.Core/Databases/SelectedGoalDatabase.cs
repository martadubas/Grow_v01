using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite.Net;
using TestDemo.Core.Interfaces;
using TestDemo.Core.Models;
using MvvmCross.Platform;
using System.Threading.Tasks;
using SQLiteNetExtensions.Extensions;
using System.Diagnostics;

namespace TestDemo.Core.Database
{
    public class SelectedGoalDatabase 
    {
        private SQLiteConnection database;
        //public SelectedGoalDatabase()
        //{
        //    var sqlite = Mvx.Resolve<ISqlite>();
        //    database = sqlite.GetConnection();
        //    database.CreateTable<SelectedGoal>();
        //}
        public SelectedGoalDatabase(ISqlite sqlite)
        {
            //var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<SelectedGoal>();
        }

        //public async Task<IEnumerable<SelectedGoal>> GetSelectedGoals()
        public List<SelectedGoal> GetSelectedGoals()
        {
            //database.GetChildren(Goal);
            return database.GetAllWithChildren<SelectedGoal>();
            //return database.Table<SelectedGoal>().ToList();
        }

        public async Task<int> DeleteSelectedGoal(object id)
        {
            return database.Delete<SelectedGoal>(Convert.ToInt16(id));
        }

        public async Task<bool> UpdateSelectedGoal(SelectedGoal selectedGoal)
        {
            Debug.WriteLine("#### update start for selected goal = " + selectedGoal.Id+" status "+selectedGoal.Status);

            database.UpdateWithChildren(selectedGoal);
            return true;
            ////sanity check
            //SelectedGoal newSelectedGoal = GetSelectedGoal(selectedGoal.Id).Result;
            //Debug.WriteLine("#### after updated selected goal status= " + selectedGoal.Status);
            //return true;
        }

        public async Task<int> InsertSelectedGoal(SelectedGoal SelectedGoal)
        {
            var num = database.Insert(SelectedGoal);
            database.Commit();
            //Debug.WriteLine("## num in sgDb =" + num); //return 1 when it is true?
            return num;
        }

        public async Task<bool> CheckIfExists(SelectedGoal SelectedGoal)
        {
            var exists = database.Table<SelectedGoal>()
                .Any(x => x.Id == SelectedGoal.Id);
            return exists;
        }

        public async Task<int> DeleteAll()
        {
            return database.DeleteAll<SelectedGoal>();
        }

        public async Task<SelectedGoal> GetSelectedGoal(object id)
        {
            Debug.WriteLine("#### seelctedgoal DB.getGoal = " + id);
            var query = database.Query<SelectedGoal>("select * from SelectedGoal where Id = ?", id);

            return query.FirstOrDefault();

        }
    }
}