using System;
using System.Collections.Generic;
using System.Linq;
using TestDemo.Core.Interfaces;
using SQLite.Net;
using System.IO;
using SQLite.Net.Platform.XamarinAndroid;

namespace TestDemo.Droid.Database
{
    public class SqliteDroid : ISqlite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "DBSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(new SQLitePlatformAndroid(), path, false); //conn.StoreDateTimeAsTicks = false;

            // Return the database connection
            return conn;
        }



    }
}