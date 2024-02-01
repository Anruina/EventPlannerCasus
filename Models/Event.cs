namespace Library.Models
{
    
    public class Event : TableData
    {

        public string? Name { get; set; }

        public int OrganizerId { get; set; }

        public string? Description { get; set; }

        public int AddressId { get; set; }
        public Address? Address { get; set; }

        public List<Activity>? Activities { get; set; }
        public List<PlannedActivity>? PlannedActivities { get; set; }

        public EventType? Type { get; set; }

        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }

        public List<User>? Participants { get; set; }

        public int MaxParticipants { get; set; }

    }

}
