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
        public SelectedGoalDatabase()
        {
            var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<SelectedGoal>();
        }

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
            //return (List < SelectedGoal > )database.GetAllWithChildren<SelectedGoal>().OrderByDescending(sg=>sg.DateCreated);
            return database.Table<SelectedGoal>().OrderByDescending(sg => sg.DateCreated).ToList();
            //return database.Table<SelectedGoal>().ToList();
        }

        public async Task<List<SelectedGoal>> GetSelectedGoalsToday()
        {
            //database.GetChildren(Goal);
            //return database.GetAllWithChildren<SelectedGoal>();
            //return database.Table<SelectedGoal>().ToList();
            //Debug.WriteLine("#### selectedgoal DB.getgoal today");
            var now = DateTime.Now;
            var today = new DateTime(now.Year, now.Month, now.Day , 0, 0, 0).Ticks;
            //Debug.WriteLine("###############  today = " + today.ToString());
            var query = database.Query<SelectedGoal>("SELECT * FROM SelectedGoal WHERE DateCreated > ?", today.ToString());
            return query;
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
           // Debug.WriteLine("#### seelctedgoal DB.getGoal = " + id);
            var query = database.Query<SelectedGoal>("select * from SelectedGoal where Id = ?", id);

            return query.FirstOrDefault();
        }

        //public async Task<bool> DailyRefresh()
        //{

        //    Debug.WriteLine("#### daily refresh");
        //    var now = DateTime.Now;
        //    var today = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0).Ticks;
        //    //Debug.WriteLine("###############  today = " + today.ToString());
        //    var query = database.Query<SelectedGoal>("SELECT * FROM SelectedGoal WHERE DateUpdated < ? AND Status='STARTED'", today.ToString());
        //    foreach(var selectedGoal in query)
        //    {
        //        selectedGoal.expire();
        //        await UpdateSelectedGoal(selectedGoal);
        //    }
        //    return true;

        //}
        
    }
}