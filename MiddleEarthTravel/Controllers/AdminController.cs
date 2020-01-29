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
    public class AdminController : Controller
    {
        readonly MemberDAL memberSQL = new MemberDAL(ConfigurationManager.ConnectionStrings["METravelDB"].ConnectionString);
        public ActionResult Index()
        {
            Member credentials = Session["member"] as Member;
            if (!credentials.IsAdmin)
            {
                TempData["msg"] = "not_admin";
                return RedirectToAction("Index", "Home");
            }
            List<Member> adminRequesters = memberSQL.GetAdminRequests();
 
            return View(adminRequesters);
        }

        public ActionResult Approve(int memberID)
        {
            memberSQL.AdminApprove(memberID);
            return RedirectToAction("Index");
        }
        public ActionResult Deny(int memberID)
        {
            memberSQL.AdminDeny(memberID);
            return RedirectToAction("Index");
        }
    }
}