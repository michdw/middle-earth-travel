using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiddleEarthTravel.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string About { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime MemberSince { get; set; }


        public List<Comment> Comments()
        {
            return null;
        }
    }
}