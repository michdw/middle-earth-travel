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
        public string Region { get; set; }
        public int Status { get; set; }
        public DateTime TimeOf { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public Dictionary<int, string> StatusOptions = new Dictionary<int, string>()
        {
            {0, "resolved" },
            {1, "mild" },
            {2, "moderate" },
            {3, "severe" }
        };

        readonly string connectionString = ConfigurationManager.ConnectionStrings["METravelDB"].ConnectionString;

        public List<Comment> Comments()
        {
            return null;
        }

        public Boolean MemberIsAdmin()
        {
            return false;
        }

        public List<SelectListItem> SelectStatus()
        {
            List<SelectListItem> statusList = StatusOptions.Select(x => new SelectListItem() { Value = x.Key.ToString(), Text = x.Value }).ToList();
            return statusList;
        }

        public List<SelectListItem> SelectRegion()
        {
            HazardDAL hazardSQL = new HazardDAL(connectionString);
            List<string> allRegions = hazardSQL.GetAllRegions();

            List<SelectListItem> regionList = allRegions.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            return regionList;
        }
    }
}