using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiddleEarthTravel.Models
{
    public class Hazard
    {
        public DateTime TimeOf { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public List<Comment> Comments()
        {
            return null;
        }

        public DateTime MostRecentUpdate()
        {
            return DateTime.Now;
        }
    }
}