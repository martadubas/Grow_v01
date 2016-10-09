﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public async Task<SelectedGoal> GetSelectedGoal(object id)
        {
            var query = database.Query<SelectedGoal>("select * from SelectedGoal where Id = ?", id);

            return query.FirstOrDefault();

        }

        public async Task<int> InsertSelectedGoal(SelectedGoal SelectedGoal)
        {
            var num = database.Insert(SelectedGoal);
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
    }
}