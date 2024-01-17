using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Schedule : TableData 
    {

        /// <summary>
        /// no properties
        /// </summary>
        /// 
        //relations
        public Event? Event { get; set; }

        //Note to Tristan: neem aan dat je dit bedoelde? lol *confused look at classdiagram* 
        public List<KeyValuePair<Activity, DateTime>>? Activities { get; set; }
    }
}
