using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    
    public class Event : TableData
    {

        public string? Name { get; set; }

        public int OrganizerId { get; set; }
        public Organizer? Organizer { get; set; }

        public int AddressId { get; set; }
        public Address? Address { get; set; }

        public List<Activity>? Activities { get; set; }
        public List<PlannedActivity>? PlannedActivities { get; set; }

        public EventType? Type { get; set; }

        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        public int MaxParticapents { get; set; }

    }

}
