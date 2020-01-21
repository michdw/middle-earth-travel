using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RangersOfTheNorth.Controllers
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

        public ActionResult Report()
        {
            return View();
        }
        public ActionResult ReportSubmit()
        {
            return View("List");
        }

        public ActionResult Update()
        {
            return View();
        }
        public ActionResult UpdateSubmit()
        {
            return View("List");
        }

        public ActionResult Status()
        {
            return null;
        }
        public ActionResult StatusSubmit()
        {
            return View("List");
        }
    }
}