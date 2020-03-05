using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MiddleEarthTravel.Models;
using Dapper;

namespace MiddleEarthTravel.DAL
{
    public class HazardDAL
    {
        readonly string connectionString;
        public HazardDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        readonly string getAllRegions = "SELECT name FROM [regions]";
        readonly string getHazardsByRecent = "SELECT * FROM [hazards] ORDER BY TimeOf DESC";
        readonly string getHazardsByPlace = "SELECT * FROM [hazards] ORDER BY RegionID";
        readonly string getRegionID = "SELECT id FROM [regions] WHERE name = @regionName";
        readonly string getRegionName = "SELECT name FROM [regions] WHERE id = @regionID";
        readonly string addNewHazard = "INSERT INTO [hazards] (RegionID, Status, TimeOf, Location, Description) " +
            "VALUES (@regionID, @status, @timeof, @location, @description)";

        public List<string> GetAllRegions()
        {
            using SqlConnection db = new SqlConnection(connectionString);
            return db.Query<string>(getAllRegions).ToList();
        }

        public string GetRegionName(int regionID)
        {
            using SqlConnection db = new SqlConnection(connectionString);
            return db.Query<string>(getRegionName, new { regionID }).FirstOrDefault();
        }

        public void ReportHazard(Hazard newHazard)
        {
            //get region id by querying regions table
            using SqlConnection db = new SqlConnection(connectionString);
            int regionID = db.Query<int>(getRegionID, new { regionName = newHazard.RegionName }).ToArray().FirstOrDefault();

            //sql insert in hazards table
            db.Execute(addNewHazard, new { regionID, newHazard.Status, newHazard.TimeOf, newHazard.Location, newHazard.Description });
        }

        public List<Hazard> GetHazardsByRecent()
        {
            using SqlConnection db = new SqlConnection(connectionString);
            List<Hazard> list = db.Query<Hazard>(getHazardsByRecent).ToList();
            return list;
        }

        public List<Hazard> GetHazardsByPlace()
        {
            using SqlConnection db = new SqlConnection(connectionString);
            List<Hazard> list = db.Query<Hazard>(getHazardsByPlace).ToList();
            return list;
        }


    }
}