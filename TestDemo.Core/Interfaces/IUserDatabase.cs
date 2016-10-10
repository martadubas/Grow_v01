using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDemo.Core.Models;

namespace TestDemo.Core.Interfaces
{
    public interface IUserDatabase
    {
        Task<IEnumerable<User>> GetUsers();

        Task<int> DeleteUser(object id);

        Task<int> InsertUser(User user);




    }
}

