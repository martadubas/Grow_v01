using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite.Net;

namespace TestDemo.Core.Interfaces
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}