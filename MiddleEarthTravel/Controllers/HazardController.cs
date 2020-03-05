using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiddleEarthTravel.DAL;
using MiddleEarthTravel.Models;

namespace MiddleEarthTravel.Controllers
{
    public class HazardController : Controller
    {
        readonly HazardDAL hazardSQL = new HazardDAL(ConfigurationManager.ConnectionStrings["METravelDB"].ConnectionString);

        public ActionResult Index(string arrange)
        {
            //use arrange to determine how to list hazards
            Hazard list = new Hazard();

            return View("List", list );
        }

        public ActionResult GetDetail()
        {
            //check member credentials, pass them in model?

            return View("Detail");
        }

        public ActionResult ReportStart()
        {
            Hazard newHazard = new Hazard();
            return View("Report", newHazard);
        }
        public ActionResult ReportSubmit(Hazard newHazard)
        {
            newHazard.TimeOf = DateTime.Now;
            hazardSQL.ReportHazard(newHazard);
            TempData["msg"] = "hazard_reported";
            return View("List");
        }

        public ActionResult UpdateStart()
        {
            return View();
        }
        public ActionResult UpdateSubmit()
        {
            return View("List");
        }

        public ActionResult StatusStart()
        {
            return null;
        }
        public ActionResult StatusSubmit()
        {
            return View("List");
        }
    }
}