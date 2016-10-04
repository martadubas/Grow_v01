namespace TestDemo.Core.Models
{
    public class Goal
    {
        public string GoalDescription { get; set; }

        public Goal() { }
        public Goal(string goalDescription)
        {
            GoalDescription = goalDescription;
        }
    }

}
