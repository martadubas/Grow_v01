using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite.Net;
using TestDemo.Core.Interfaces;
using TestDemo.Core.Models;
using MvvmCross.Platform;
using System.Threading.Tasks;

namespace TestDemo.Core.Interface
{
    public interface IGoalDatabase
    {
        Task<IEnumerable<Goal>> GetGoals();
        Goal GetTheFirstGoal();
        Task<int> DeleteGoal(object id);
        Task<Goal> GetGoal(object id);
        Task<int> InsertGoal(Goal Goal);
        Task<bool> CheckIfExists(Goal Goal);
        Task<int> DeleteAll();

    }
}