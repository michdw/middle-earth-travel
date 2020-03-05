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
        readonly string connectionString = ConfigurationManager.ConnectionStrings["METravelDB"].ConnectionString;

        public int ID { get; set; }
        public int RegionID { get; set; }
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

        public string RegionName
        {
            get
            {
                HazardDAL hazardSQL = new HazardDAL(connectionString);
                return hazardSQL.GetRegionName(RegionID);
            }
        }

        public List<Comment> Comments
        {
            get
            {
                return null;
            }
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

        public List<Hazard> AllByRecent()
        {
            HazardDAL hazardSQL = new HazardDAL(connectionString);
            return hazardSQL.GetHazardsByRecent();
        }

        public List<Hazard> AllByPlace()
        {
            HazardDAL hazardSQL = new HazardDAL(connectionString);
            return hazardSQL.GetHazardsByPlace();
        }
    }
}