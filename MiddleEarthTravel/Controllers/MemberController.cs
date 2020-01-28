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
    public class MemberController : Controller
    {
        readonly MemberDAL memberSQL = new MemberDAL(ConfigurationManager.ConnectionStrings["METravelDB"].ConnectionString);

        public ActionResult Index(string arrange)
        {
            ViewBag.arrange = arrange;
            return View("List");
        }

        public ActionResult OwnInfo()
        {
            Member credentials = Session["member"] as Member;
            return View(credentials);
        }

        public ActionResult ChangeName()
        {
            return View("Index", "Home");
        }
        public ActionResult ChangePassword()
        {
            return View("Index", "Home");
        }        
        public ActionResult RemoveMember()
        {
            return View("Index", "Home");
        }

        public ActionResult OtherMemberInfo()
        {
            return View("MemberInfo");
        }

    }
}