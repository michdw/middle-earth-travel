﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiddleEarthTravel.DAL;
using MiddleEarthTravel.Models;


namespace MiddleEarthTravel.Controllers
{
    public class HomeController : Controller
    {
        readonly MemberDAL memberSQL = new MemberDAL(ConfigurationManager.ConnectionStrings["METravelDB"].ConnectionString);


        public ActionResult Index()
        {
            Member credentials = new Member();
            if (Session["member"] != null)
            {
                credentials = Session["member"] as Member;
                ViewBag.name = credentials.DisplayName;
            }
            return View(credentials);
        }

        public ActionResult RegisterStart()
        {
            Member newMember = new Member();
            return View("Register", newMember);
        }
        public ActionResult Register(Member newMember)
        {
            if (newMember.DisplayName == null || newMember.Password == null)
            {
                ModelState.AddModelError("register-error", "missing name or password");
                return View("Register", newMember);
            }

            bool nameExists = memberSQL.CheckForNameNocase(newMember.DisplayName);
            if (nameExists)
            {
                ModelState.AddModelError("register-error", "name already in use");
                return View("Register", newMember);
            }

            if (newMember.Password != newMember.ConfirmPassword)
            {
                ModelState.AddModelError("register-error", "passwords dont match");
                return View("Register", newMember);
            }

            newMember.MemberSince = DateTime.Now;
            memberSQL.RegisterMember(newMember);
            Session["member"] = memberSQL.GetMemberByName(newMember.DisplayName);
            TempData["msg"] = "register";
            return RedirectToAction("Index");
        }


        public ActionResult LoginStart()
        {
            Member member = new Member();
            return View("Login", member);
        }
        public ActionResult Login(Member credentials)
        {

            if (credentials.DisplayName == null || credentials.Password == null)
            {
                ModelState.AddModelError("login-error", "null name or password");
                return View("Login", credentials);
            }

            bool nameExists = memberSQL.CheckForNameCase(credentials.DisplayName);
            if (!nameExists)
            {
                ModelState.AddModelError("login-error", "name not found");
                return View("Login", credentials);
            }

            Member member = memberSQL.GetMemberByName(credentials.DisplayName);
            if (member.Password != credentials.Password)
            {
                ModelState.AddModelError("login-error", "incorrect password");
                return View("Login", credentials);
            }

            Session["member"] = member;
            TempData["msg"] = "login";
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session["member"] = null;
            TempData["msg"] = "logout";
            return RedirectToAction("Index");
        }

    }
}