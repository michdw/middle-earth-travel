using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RangersOfTheNorth.Models
{
    public class Member
    {
        public string MemberID { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string MemberName { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords don't match")]
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