using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
namespace TestDemo.Core.Models
{
    public class Goal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public DateTime DateCreated { get; set; }
    

        public string Category { get; set; }

        public Goal(string title, string description, string category)
        {
            Title = title;
            Description = description;
            Category = category;
            //DateCreated = DateTime.Now;
        }
        public Goal()
        {
            Title = "Default title";
            Description = "default description";
            Category = "default category";
        }

        public override string ToString()
        {
            return Title;
        }

        public void updateTitle(String status)
        {
            if (status == null)
            {
                return;
            }
            switch (status)
            {
                case "STARTED":
                case "COMPLETED":
                    Title = "["+status+"] "+Title;
                    break;
                default:
                    break;
            }
        }

    }

}
