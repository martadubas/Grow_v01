using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System.Diagnostics;

namespace TestDemo.Core.Models
{
    public class SelectedGoal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateCreated { get; set; }
        [ForeignKey(typeof(Goal))]
        public int GoalId { get; set; } //foreign key
        [ManyToOne]
        public Goal Goal { get; set; }
        [Ignore]
        public string Category { get; set; }
        [Ignore]
        public string Title { get; set; }
        public byte[] Photo { get; set; }
        
        public SelectedGoal(Goal goal)
        {
            Goal = goal;
            GoalId = goal.Id;
            Status = "STARTED";
            Title = goal.Title;
            Category = goal.Category;
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }
        public SelectedGoal()
        {
            Goal = new Goal();
            Status = "STARTED";
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }

        public void complete()
        {
            Status = "COMPLETED";
            updateDate();

        }
        public void delete()
        {
            Status = "DELETED";
            updateDate();
        }

        public void expire()
        {
            Status = "EXPIRED";
            updateDate();
        }

        private void updateDate()
        {
            DateUpdated = DateTime.Now;
            //Debug.WriteLine("### update date = " + DateUpdated);

        }
        public void setGoal(Goal goal)
        {
            this.Goal = goal;
            this.Title = goal.Title;
            this.Category = goal.Category;
            
        }
        public string toString()
        {
            
            return ">>Goal " + Goal.Title + " - Status " + Status + " - updated " + DateUpdated + " - goalId " + GoalId+ "<< " ;
        }       


    }
}