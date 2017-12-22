using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datalayer;
using Datalayer.Entities;

namespace Dating.Controllers
{
    public class LoginController : Controller
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
                var id = int.Parse(Session["UserID"].ToString());
                var usr = db.Users.Single(u => u.Id == id);
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