namespace Library.Models
{
    
    public class Activity : TableData
    {

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Room { get; set; }

        public DateTime? Duration { get; set; }

        public int EventId { get; set; }
        public Event? Event { get; set; }

        public List<PlannedActivity>? PlannedActivities { get; set; }

    }

}
