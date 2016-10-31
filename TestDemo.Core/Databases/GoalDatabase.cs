//author: Elvin Prananta
using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using TestDemo.Core.Interfaces;
using TestDemo.Core.Models;
using MvvmCross.Platform;
using System.Threading.Tasks;

namespace TestDemo.Core.Database
{
    public class GoalDatabase
    {
        private SQLiteConnection database;
     
        public GoalDatabase(ISqlite sqlite)
        {
            database = sqlite.GetConnection();
            database.CreateTable<Goal>();
        }

        public GoalDatabase()
        {
            var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<Goal>();
        }

        public async Task<IEnumerable<Goal>> GetGoals()
        {
            return database.Table<Goal>().ToList();
        }

        public Goal GetTheFirstGoal()
        {
            return GetGoals().Result.FirstOrDefault();
        }

        public async Task<int> DeleteGoal(object id)
        {
            return database.Delete<Goal>(Convert.ToInt16(id));
        }
        public async Task<Goal> GetGoal(object id)
        {
            //Debug.WriteLine("#### goal DB.getGoal = " + id);
            var query =  database.Query<Goal>("select * from Goal where Id = ?", id);

            return query.FirstOrDefault();
            
        }

        public async Task<int> InsertGoal(Goal Goal)
        {
            var num = database.Insert(Goal);
            database.Commit();
            return num;
        }

        public async Task<bool> CheckIfExists(Goal Goal)
        {
            var exists = database.Table<Goal>()
                .Any(x => x.Title == Goal.Title);
            return exists;
        }

        public async Task<int> DeleteAll()
        {
            return database.DeleteAll<Goal>();
        }
    }
}