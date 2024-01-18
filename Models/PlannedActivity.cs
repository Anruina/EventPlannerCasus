using System.Text.Json.Serialization;

namespace Library.Models
{
    
    public class PlannedActivity : TableData 
    {

        public Activity? Activity { get; set; }

        [JsonIgnore]
        public List<Participant>? Participants { get; set; }

        public DateTime TimeSlot { get; set; }

    }

}
