using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dating.Models
{
    public class FriendModel
    {
        public virtual int friend1 { get; set; }
        public virtual int friend2 { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}