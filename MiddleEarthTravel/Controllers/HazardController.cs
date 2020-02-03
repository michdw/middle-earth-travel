using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiddleEarthTravel.Models;

namespace MiddleEarthTravel.Controllers
{
    public class HazardController : Controller
    {
        public ActionResult Index(string arrange)
        {
            ViewBag.arrange = arrange;
            return View("List");
        }

        public ActionResult GetDetail()
        {
            return View("Detail");
        }

        public ActionResult ReportStart()
        {
            Hazard newHazard = new Hazard();
            
            return View("Report", newHazard);
        }
        public ActionResult ReportSubmit()
        {
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