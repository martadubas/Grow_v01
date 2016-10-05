namespace TestDemo.Core.Models
{
    public class Goal
    {
        
        public string Title { get; set; }
        public string Description { get; set; }

        public string Category { get; set; }

        public Goal(string title, string description, string category)
        {
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

    }

}
