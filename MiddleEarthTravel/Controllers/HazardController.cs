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
            //sql to get hazards by most recent -> to List<Hazard> for model

            return View("List");
        }

        public ActionResult GetDetail()
        {
            //check member credentials, pass in model?

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