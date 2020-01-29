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

        [HttpPost]
        public ActionResult ChangeName(Member member)
        {
            if(memberSQL.CheckForDisplayName(member.DisplayName))
            {
                TempData["msg"] = "name_exists";
                return RedirectToAction("OwnInfo");
            }
            memberSQL.ChangeName(member.DisplayName, member.ID);
            member = memberSQL.GetMemberByID(member.ID);
            Session["member"] = member;
            TempData["msg"] = "name_changed";

            return RedirectToAction("OwnInfo");
        }

        [HttpPost]
        public ActionResult ChangePassword()
        {
            return View("Index", "Home");
        }

        [HttpPost]
        public ActionResult ChangeAboutMember()
        {
            return View("Index", "Home");
        }        

        [HttpPost]
        public ActionResult RemoveMember()
        {
            return View("Index", "Home");
        }

        public ActionResult AdminRequest(int memberID)
        {
            memberSQL.AdminRequest(memberID);
            return RedirectToAction("OwnInfo");
        }

        public ActionResult OtherMemberInfo()
        {
            return View("MemberInfo");
        }


    }
}