using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RangersOfTheNorth.Controllers
{
    public class MemberController : Controller
    {
        public ActionResult Index(string arrange)
        {
            ViewBag.arrange = arrange;
            return View("List");
        }

        public ActionResult OwnInfo()
        {
            return View();
        }

        public ActionResult ChangeInfo()
        {
            return View("OwnMemberInfo");
        }

        public ActionResult OtherMemberInfo()
        {
            return View("MemberInfo");
        }

        public ActionResult RequestMakeAdmin()
        {
            return null;
        }
        public ActionResult AdminApprove()
        {
            return null;
        }
        public ActionResult AdminDeny()
        {
            return null;
        }
    }
}