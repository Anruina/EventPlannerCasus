namespace Library.Models
{
    
    public class Organizer : TableData
    {

        //properties
        public string? Name { get; set; }
        public string? AuthenticationId { get; set; }

        //relations
        public List<Event>? OrganizedEvents { get; set; }

        public string? MailAddress { get; set; }
        public string? PhoneNumber { get; set; }

    }

}
