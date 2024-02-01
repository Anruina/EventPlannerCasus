namespace Library.Models
{
    
    public class Participant : TableData
    {

        public string? Name { get; set; }
        public string? AuthenticationId { get; set; }

        public string? MailAddress { get; set; }

        public string? PhoneNumber { get; set; }

        public List<Event>? VisitedEvents { get; set; }

        public List<PlannedActivity>? VisitedActivities { get; set; }

        public Address? Address { get; set; }

    }

}
