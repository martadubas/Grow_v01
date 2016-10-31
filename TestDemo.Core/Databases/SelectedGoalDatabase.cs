//author: Elvin Prananta
using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using TestDemo.Core.Interfaces;
using TestDemo.Core.Models;
using MvvmCross.Platform;
using System.Threading.Tasks;
using SQLiteNetExtensions.Extensions;

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
            database = sqlite.GetConnection();
            database.CreateTable<SelectedGoal>();
        }

        public List<SelectedGoal> GetSelectedGoals()
        {
            return database.Table<SelectedGoal>().OrderByDescending(sg => sg.DateCreated).ToList();
        }

        public async Task<List<SelectedGoal>> GetSelectedGoalsToday()
        {
            var query = database.Query<SelectedGoal>("SELECT * FROM SelectedGoal WHERE DateCreated >= date('now','localtime','start of day')");
            return query;
        }

        public async Task<int> DeleteSelectedGoal(object id)
        {
            return database.Delete<SelectedGoal>(Convert.ToInt16(id));
        }

        public bool UpdateSelectedGoal(SelectedGoal selectedGoal)
        {
            database.UpdateWithChildren(selectedGoal);
            return true;
        }

        public async Task<int> InsertSelectedGoal(SelectedGoal selectedGoal)
        {
            var num = database.Insert(selectedGoal);

            database.Commit();
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
            var query = database.Query<SelectedGoal>("select * from SelectedGoal where Id = ?", id);

            return query.FirstOrDefault();
        }

        
    }
}