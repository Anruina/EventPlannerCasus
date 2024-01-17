using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Organizer : TableData
    {

        //properties
        public string? Name { get; set; }
        public List<string>? Permits { get; set; }

        //relations
        public Event? Event { get; set; }
    }
}
