namespace Library.Models
{
   
    public class Address : TableData
    {

        public string? Country { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public int? StreetNumber { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? AdditionHouseNumber { get; set; }

        List<Event>? Events { get; set; }
        List<Participant>? Participants { get; set; }

    }
    
}
