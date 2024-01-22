namespace Library.Models
{

    public class Organizer : User
    {

        public List<Event>? OrganizedEvents { get; set; }

        public string? MailAddress { get; set; }
        public string? PhoneNumber { get; set; }

        public static implicit operator Organizer(Participant participant)
        {

            return new Organizer() { Id = participant.Id, AuthenticationId = participant.AuthenticationId, Name = participant.Name };

        }

    }

}
