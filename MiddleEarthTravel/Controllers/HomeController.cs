using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RangersOfTheNorth.DAL;
using RangersOfTheNorth.Models;


namespace RangersOfTheNorth.Controllers
{
    public class HomeController : Controller
    {
        readonly MemberDAL memberSQL = new MemberDAL(ConfigurationManager.ConnectionStrings["METravelDB"].ConnectionString);

        public ActionResult Index()
        {
            if (Session["member"] != null)
            {
                ViewBag.member = Session["member"].ToString();
            }
            return View();
        }

        public ActionResult RegisterStart()
        {
            Member newMember = new Member();
            return View("Register", newMember);
        }
        public ActionResult Register(Member newMember)
        {
            //ActionResult RegisterError(string message)
            //{
            //    ModelState.AddModelError("invalid-credentials", message);
            //    return RedirectToAction("RegisterStart");
            //}

            //any missing fields?
            if (newMember.MemberName == null || newMember.Password == null)
            {
                ModelState.AddModelError("invalid-credentials", "Please enter a name and password");
                return RedirectToAction("RegisterStart");
            }

            //member name exists?

            bool nameExists = memberSQL.CheckForMemberName(newMember.MemberName);
            if (nameExists)
            {
                ModelState.AddModelError("invalid-credentials", "Please enter a name and password");
                return RedirectToAction("RegisterStart");
            }

            //passwords dont match?



            Session["member"] = newMember.MemberName;
            newMember.MemberSince = DateTime.Now;
            memberSQL.RegisterMember(newMember);
            return RedirectToAction("Index");
        }

        public ActionResult LoginStart()
        {
            Member member = new Member();
            return View("Login", member);
        }
        public ActionResult Login(Member currentMember)
        {
            //any missing fields?

            //get member by member name

            //member name not found?

            //wrong password?

            Session["memberID"] = currentMember.MemberID;
            return RedirectToAction("Home");
        }

        public ActionResult Logout()
        {
            Session["memberID"] = null;
            ViewBag.msg = "logged out";
            return View("Index");
        }

    }
}