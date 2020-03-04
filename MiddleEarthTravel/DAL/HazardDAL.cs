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
        readonly string getRegionIDByName = "SELECT id FROM [regions] WHERE name = @regionName";
        readonly string addNewHazard = "INSERT INTO [hazards] (RegionID, Status, TimeOf, Location, Description) " +
            "VALUES (@regionID, @status, @timeof, @location, @description)";

        public List<string> GetAllRegions()
        {
            using SqlConnection db = new SqlConnection(connectionString);
            return db.Query<string>(getAllRegions).ToList();
        }

        public void ReportHazard(Hazard newHazard)
        {
            //get region id by querying regions table
            using SqlConnection db = new SqlConnection(connectionString);
            int regionID = db.Query<int>(getRegionIDByName, new { regionName = newHazard.Region }).ToArray().FirstOrDefault();

            //sql insert in hazards table
            db.Execute(addNewHazard, new { regionID, newHazard.Status, newHazard.TimeOf, newHazard.Location, newHazard.Description });
        }

        
    }
}