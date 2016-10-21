using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo.Core.Models
{
    public class User
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Username { get; set; }
        public int Avatar { get; set; }// 0=bird, 1=butterfly, 2=diamond
        public int CompletedGoal { get; set; }       
        public int AvatarLevel { get; set; }
       

    }
}
