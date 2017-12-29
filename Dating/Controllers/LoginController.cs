using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datalayer;
using Datalayer.Entities;

namespace Dating.Controllers
{
    public class LoginController : StartController
    {
        [HttpPost]
        public ActionResult Login(User user)
        {
            try
            {
                using (Datacontext db = new Datacontext())
                {
                    var usr = db.Users.Single(u => u.Email == user.Email && u.Password == user.Password);
                    if (usr != null)
                    {
                        Session["UserID"] = usr.Id.ToString();
                        return RedirectToAction("LoggedIn");
                    }
                }
            }
            catch
            {
                ModelState.AddModelError("", "Wrong email or password");
                return View("LogInView");
            }
            return View("LoggedIn");
        }


        public ActionResult Login()
        {
            if (Session["UsedID"] != null)
            {
                return View("LoggedIn");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


        public ActionResult LoggedIn()
        {
            using (Datacontext db = new Datacontext())
            {
                var id = Convert.ToInt32(Session["UserID"]);
                var usr = db.Users.Single(u => u.Id == id);
                var listPost = new PostController().OldPosts(id);
                var TotalContentList = new List<string[]>();
                foreach (Posts post in listPost)
                {
                    User Sender = db.Users.Find(post.SenderID);
                    string name = Sender.Firstname + " " + Sender.Lastname;
                    string[] totalContentArray = new string[2] { name, post.TextContent };
                    TotalContentList.Add(totalContentArray);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                ViewBag.PostsForUser = TotalContentList;
                return View(usr);
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Remove("UserID");
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LogInView()
        {
            return View();
        }
    }
}