namespace Library.Models
{
    
    public enum UserType { Participant, Organizer };

    public class User : TableData
    {

        public string? Name { get; set; }
        public string? AuthenticationId { get; set; }

        public UserType Type { get; set; }

        public string? MailAddress { get; set; }

        public string? PhoneNumber { get; set; }

        public List<Event>? VisitedEvents { get; set; }

        public List<PlannedActivity>? VisitedActivities { get; set; }

        public Address? Address { get; set; }

    }

}
