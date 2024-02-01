﻿using System.Text.Json.Serialization;

namespace Library.Models
{
    
    public class PlannedActivity : TableData 
    {

        public Activity? Activity { get; set; }

        [JsonIgnore]
        public List<User>? Participants { get; set; }

        public DateTime TimeSlot { get; set; }

    }

}
