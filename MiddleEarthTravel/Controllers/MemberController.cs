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
            if(memberSQL.CheckForNameSens(member.DisplayName))
            {
                ModelState.AddModelError("changename-error", "That name already exists");
                return RedirectToAction("OwnInfo");
            }
            memberSQL.ChangeName(member.DisplayName, member.ID);
            Session["member"] = memberSQL.GetMemberByID(member.ID);
            TempData["msg"] = "name_changed";

            return RedirectToAction("OwnInfo");
        }

        [HttpPost]
        public ActionResult ChangePassword(Member member)
        {
            if (member.Password != member.ConfirmPassword)
            {
                ModelState.AddModelError("changepassword-error", "Passwords don't match");
                return RedirectToAction("OwnInfo");
            }
            memberSQL.ChangePassword(member.Password, member.ID);
            Session["member"] = memberSQL.GetMemberByID(member.ID);
            TempData["msg"] = "password_changed";
            return RedirectToAction("OwnInfo");
        }

        [HttpPost]
        public ActionResult ChangeAboutText(Member member)
        {
            memberSQL.ChangeAboutText(member.About, member.ID);
            Session["member"] = memberSQL.GetMemberByID(member.ID);
            TempData["msg"] = "about_changed";
            return RedirectToAction("OwnInfo");
        }        

        public ActionResult AdminRequest(int memberID)
        {
            memberSQL.AdminRequest(memberID);
            TempData["msg"] = "admin_request";
            return RedirectToAction("OwnInfo");
        }

        public ActionResult OtherMemberInfo()
        {
            return View("MemberInfo");
        }


    }
}