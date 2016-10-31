//author: Elvin Prananta
using System;
using SQLite.Net.Attributes;
namespace TestDemo.Core.Models
{
    public class Goal
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Category { get; set; }

        public Goal(int id, string title, string description, string category)
        {
            Id = id;
            Title = title;
            Description = description;
            Category = category;
            
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
