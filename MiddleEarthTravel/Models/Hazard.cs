using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiddleEarthTravel.DAL;

namespace MiddleEarthTravel.Models
{
    public class Hazard
    {
        public int ID { get; set; }
        public DateTime TimeOf { get; set; }
        public string Location { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }


        readonly string connectionString = ConfigurationManager.ConnectionStrings["METravelDB"].ConnectionString;

        public List<Comment> Comments()
        {
            return null;
        }

        public DateTime MostRecentUpdate()
        {
            return DateTime.Now;
        }

        public List<string> GetAllRegions()
        {
            HazardDAL hazardSQL = new HazardDAL(connectionString);
            return hazardSQL.GetAllRegions();
        }

        public List<SelectListItem> SelectRegion()
        {
            HazardDAL hazardSQL = new HazardDAL(connectionString);
            List<string> allRegions = hazardSQL.GetAllRegions();

            List<SelectListItem> dropdown = allRegions.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            return dropdown;
        }
    }
}