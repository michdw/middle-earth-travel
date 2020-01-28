using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiddleEarthTravel.Models
{
    public class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }

        public List<Hazard> Hazards()
        {
            return null;
        }
    }
}