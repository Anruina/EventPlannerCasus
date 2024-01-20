namespace Library.Models
{
    
    public class Participant : User
    {

        public List<Event>? VisitedEvents { get; set; }

        public List<PlannedActivity>? VisitedActivities { get; set; }

        public Address? Address { get; set; }

    }

}
