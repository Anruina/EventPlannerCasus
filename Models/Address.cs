using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Address : TableData
    {
        //properties
        public string? Country { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public int? StreetNumber { get; set; }
        public string? City { get; set; }

        //might help people see if the event is nearby or not -- not every city/town name is wellknown.
        // - feel free to remove this if you deem it unneccesary.
        public string? Province { get; set; }

        //added this, because house number like 24A exist. -- can be a seperate " optional " field.
        public string? AdditionHouseNumber { get; set; }


    }
}
