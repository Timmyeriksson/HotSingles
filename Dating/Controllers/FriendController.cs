using Datalayer;
using Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dating.Controllers
{
    public class FriendController : StartController
    {

        // GET: Friend
        public ActionResult Index()
        {
            return View();
        }

        // GET: Friend


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

        public ActionResult FriendProfile(int? id)
        {

            if (Session["UserID"] != null)
            {
                int currentUser = Convert.ToInt32(Session["UserID"]);
                int userid = Convert.ToInt32(id);

                if (currentUser == userid)
                {
                    return RedirectToAction("LoggedIn", "Login");
                }
                else
                {



                    using (Datacontext db = new Datacontext())
                    {
                        User user = db.Users.Find(id);
                        if (user == null)
                        {
                            return HttpNotFound();
                        }
                        ViewBag.IsFriends = false;
                        if (IsFriends(currentUser, userid))
                        {
                            ViewBag.IsFriends = true;
                        }
                        ViewBag.ProfilId = userid;
                        return View(user);
                    }
                }
            }
            else
            {
                return RedirectToAction("LoginView", "Login");
            }
        }

        public bool IsFriends(int id1, int id2)
        {
            using (Datacontext db = new Datacontext())
            {
                var allFriends = db.Friends.ToList();
                foreach (Friend friend in allFriends)
                {
                    if ((friend.Friend1 == id1 && friend.Friend2 == id2) || (friend.Friend2 == id1 && friend.Friend1 == id2))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public ActionResult AddFriend(int id)
        {
            using (Datacontext db = new Datacontext())
            {
                Friend friend = new Friend();
                friend.Friend1 = Convert.ToInt32(Session["UserID"]);
                friend.Friend2 = id;
                friend.Accepted = false;
                db.Friends.Add(friend);
                db.SaveChanges();
                return RedirectToAction("FriendProfile", new { id = id });
            }
        }

        public ActionResult FriendRequests()
        {
            if (Session["UserID"] != null)
            {
                int currentUser = Convert.ToInt32(Session["UserID"]);
                using (Datacontext db = new Datacontext())
                {
                    var AllFriendConnections = db.Friends.ToList();
                    var PendingFriends = new List<Friend>();
                    foreach (Friend friend in AllFriendConnections)
                    {
                        if (friend.Accepted == false)
                        {
                            PendingFriends.Add(friend);
                        }
                    }
                    var PendingForUser = new List<User>();

                    var UserList = db.Users.ToList();

                    foreach (User user in UserList)
                    {
                        foreach (Friend friend in PendingFriends)
                        {
                            if ((user.Id == friend.Friend1 && currentUser == friend.Friend2) || (currentUser == friend.Friend1 && user.Id == friend.Friend2))
                            {
                                PendingForUser.Add(user);
                            }
                        }
                    }
                    return View(PendingForUser);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult AcceptFriend(int id)
        {
            var requester = id;
            var currentUser = Convert.ToInt32(Session["UserID"]);
            using (Datacontext db = new Datacontext())
            {
                var AllFriendConnections = db.Friends.ToList();
                var PendingFriends = new List<Friend>();
                foreach (Friend friend in AllFriendConnections)
                {
                    if (friend.Accepted == false)
                    {
                        PendingFriends.Add(friend);
                    }
                }
                foreach (Friend friend in PendingFriends)
                {
                    if (friend.Friend1 == id && friend.Friend2 == currentUser)
                    {
                        friend.Accepted = true;
                    }
                }

                db.SaveChanges();
                return RedirectToAction("Friends");
            }
        }

        public ActionResult DeclineFriend(int id)
        {
            var requester = id;
            var currentUser = Convert.ToInt32(Session["UserID"]);
            using (Datacontext db = new Datacontext())
            {
                var AllFriendConnections = db.Friends.ToList();
                var PendingFriends = new List<Friend>();
                foreach (Friend friend in AllFriendConnections)
                {
                    if (friend.Accepted == false)
                    {
                        PendingFriends.Add(friend);
                    }
                }
                foreach (Friend friend in PendingFriends)
                {
                    if (friend.Friend1 == id && friend.Friend2 == currentUser)
                    {
                        db.Friends.Remove(friend);
                    }
                }

                db.SaveChanges();
                return RedirectToAction("Friends");
            }
        }
    }
}