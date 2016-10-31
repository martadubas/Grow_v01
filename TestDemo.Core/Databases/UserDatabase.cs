//author:Marta Dubas
using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using TestDemo.Core.Interfaces;
using MvvmCross.Platform;
using TestDemo.Core.Models;

namespace TestDemo.Core.Database
{
    public class UserDatabase 
    {
        private SQLiteConnection database;
        public UserDatabase()
        {
            var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<User>();
        }

        public User GetUserById(int Id)
        {
    
            User user = database.Table<User>().FirstOrDefault(a => a.Id == Id);
           
            return user;
        }
        
        public IEnumerable<User> GetUsers()
        {
            return database.Table<User>().ToList();
        }

        public int DeleteUser(object id)
        {
            return database.Delete<User>(Convert.ToInt16(id));
        }

        public int DeleteAll()
        {
            var num = database.DeleteAll<User>();
            database.Commit();
            return num;
           
        }
        public int Update(object user)
        {
            var num = database.Update(user);
            database.Commit();
            return num;

        }

        public int InsertUser(User user)
        {
            var num = database.Insert(user);
            database.Commit();
            return num;
        }
     
    }
}