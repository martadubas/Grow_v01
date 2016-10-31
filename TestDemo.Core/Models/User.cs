//author:Marta Dubas
using SQLite.Net.Attributes;

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
