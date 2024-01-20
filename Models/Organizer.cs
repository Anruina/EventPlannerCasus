namespace Library.Models
{
    
    public class Organizer : User
    {

        public List<Event>? OrganizedEvents { get; set; }

        public string? MailAddress { get; set; }
        public string? PhoneNumber { get; set; }

    }

}
