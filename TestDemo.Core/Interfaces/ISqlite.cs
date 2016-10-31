using SQLite.Net;

namespace TestDemo.Core.Interfaces
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}