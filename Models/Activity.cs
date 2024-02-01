namespace Library.Models
{
    
    public class Activity : TableData
    {

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Room { get; set; }

        public TimeOnly? StartDate { get; set; }
        public TimeOnly? EndDate { get; set; }

        public int EventId { get; set; }
        public Event? Event { get; set; }

    }

}
