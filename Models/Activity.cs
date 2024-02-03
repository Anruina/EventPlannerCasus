using System.Text.Json.Serialization;

namespace Library.Models
{
    
    public class Activity : TableData
    {

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Room { get; set; }

        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }

        public int EventId { get; set; }

        [JsonIgnore]
        public Event? Event { get; set; }

        public List<User>? Users { get; set; }


    }

}
