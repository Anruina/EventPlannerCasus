namespace Library.Models
{
    
    public class Activity : TableData
    {

        public string? Name { get; set; }

        public string? Description { get; set; }
        public DateTime? Duration { get; set; }

        public int EventId { get; set; }
        public Event? Event { get; set; }

        List<PlannedActivity>? PlannedActivities { get; set; }

    }

}
