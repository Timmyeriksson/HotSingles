using Datalayer;
using Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dating.Controllers
{
    public class StartController : Controller
    {
        private Datacontext db = new Datacontext();

        public StartController()
        {
            List<Friend> PendingFriends = new List<Friend>();
            {
                var AllFriendConnections = db.Friends.ToList();
                foreach (Friend friend in AllFriendConnections)
                {
                    if (friend.Accepted == false)
                    {
                        PendingFriends.Add(friend);
                    }
                }

            }
            ViewBag.MyPendings = PendingFriends;
        }

    }
}