using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using TestDemo.Core.Interfaces;
using MvvmCross.Platform;
using System.Threading.Tasks;
using TestDemo.Core.Models;

namespace TestDemo.Core.Database
{
    public class UserDatabase : IUserDatabase
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
        
        public async Task<IEnumerable<User>> GetUsers()
        {
            return database.Table<User>().ToList();
        }

        public async Task<int> DeleteUser(object id)
        {
            return database.Delete<User>(Convert.ToInt16(id));
        }

        public async Task<int> DeleteAll()
        {
            return database.DeleteAll<User>();
           
        }
        public async Task<int> Update(object user)
        {
            return database.Update(user);
        }

        public async Task<int> InsertUser(User user)
        {
            var num = database.Insert(user);
            database.Commit();
            return num;
        }

        public bool CheckIfExists()
        {
            var exists = database.Table<User>()
                .Count() > 0;
                
                //Any(x => x.Username == user.Username
                //|| x.Id == user.Id);
            return exists;
        }

        public bool isSetUser()
        {
            if (database.Table<User>().Count() > 0) return true;

            return false;
        }
     
    }
}