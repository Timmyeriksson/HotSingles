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

        // GET: Friend
        public ActionResult FriendList()
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

        //search for a friend by firstname
        public ActionResult SearchFriend(string searchString)

        {

            using (Datacontext db = new Datacontext())
            {
                var friend = from m in db.Users
                             where m.Searchable.Equals("yes")
                             select m;

                if (!String.IsNullOrEmpty(searchString))
                {
                    friend = friend.Where(s => s.Firstname.Contains(searchString));
                }

                return RedirectToAction("FriendList");
            }
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
    }
}