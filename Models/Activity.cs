using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Activity : TableData
    {

        //properties
        public string? Name { get; set; }

        public string? Description { get; set; }
        public DateTime? Duration { get; set; }


        //relations
        public Schedule? EventSchedule { get; set; }

        public Event? Event { get; set; }
    }
}
