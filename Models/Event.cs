using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Event : TableData
    {

        //properties
        public decimal? Price { get; set; }
        public DateTime? StartEvent { get; set; }
        public DateTime? EndEvent { get; set; }


        //relations
        public Organizer? Organizer { get; set; }
        public List<Participant>? Participants { get; set; }
        public List<Activity>? Activities { get; set; }
        public Address? Address { get; set; }
        public Schedule? Schedule { get; set; }

    }
}
