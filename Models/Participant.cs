using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Participant : TableData
    {
        //properties
        public string? Name { get; set; }

        //relations
        public List<Event>? Events { get; set; }

        public List<Activity>? Activities { get; set; }

        public Address? Address { get; set; }
    }
}
