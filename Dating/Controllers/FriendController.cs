using Datalayer;
using Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dating.Controllers
{
    public class FriendController : Controller
    {
        // GET: Friend
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Friends()
        {
            if (Session["UserID"] != null)
            {
                int currentUser = Convert.ToInt32(Session["UserID"]);
                using (Datacontext db = new Datacontext())
                {
                    var AllFriendConnections = db.Friends.ToList();
                    var AcceptedFriendsList = new List<Friend>();
                    foreach (Friend friend in AllFriendConnections)
                    {
                        if (friend.Accepted == true)
                        {
                            AcceptedFriendsList.Add(friend);
                        }
                    }
                    var MyAcceptedFriendsAsUsers = new List<User>();

                    var UserList = db.Users.ToList();

                    foreach (User user in UserList)
                    {
                        foreach (Friend friend in AcceptedFriendsList)
                        {
                            if ((user.Id == friend.Friend1 && currentUser == friend.Friend2) || (currentUser == friend.Friend1 && user.Id == friend.Friend2))
                            {
                                MyAcceptedFriendsAsUsers.Add(user);
                            }
                        }
                    }
                    return View(MyAcceptedFriendsAsUsers);
                }
            }
            return RedirectToAction("Index");

        }

        public ActionResult FriendList()
        {
            return View();
        }
    }
}