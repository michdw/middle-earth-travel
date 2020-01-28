using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiddleEarthTravel.Models
{
    public class Comment
    {
        public Member Commenter { get; set; }
        public DateTime TimeOf { get; set; }
        public string CommentText { get; set; }
    }
}