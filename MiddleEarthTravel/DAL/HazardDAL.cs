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

        readonly string getAllRegions = "SELECT Name from [regions]";


        public List<string> GetAllRegions()
        {
            using SqlConnection db = new SqlConnection(connectionString);
            return db.Query<string>(getAllRegions).ToList();
        }
    }
}