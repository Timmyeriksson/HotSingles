using Datalayer;
using Dating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dating.Controllers
{
    public class EditAccountController : StartController
    {
        // GET: EditAccount
        public ActionResult EditAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditMail(editwrapper edit)
        {
            try
            {
                using (Datacontext db = new Datacontext())
                {
                    var id = int.Parse(Session["UserID"].ToString());
                    var usr = db.Users.Single(u => u.Id == id);
                    usr.Email = edit.mailen.Email;

                    db.SaveChanges();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong, please try again.");
                return View("EditAccount");
            }
            return RedirectToAction("EditAccount");
        }

        [HttpPost]
        public ActionResult EditPassword(editwrapper edit)
        {
            try
            {
                using (Datacontext db = new Datacontext())
                {
                    var id = int.Parse(Session["UserID"].ToString());
                    var usr = db.Users.Single(u => u.Id == id);
                    usr.Password = edit.Password.Password;

                    db.SaveChanges();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong, please try again.");
                return View("EditAccount");
            }
            return RedirectToAction("EditAccount");
        }

        [HttpPost]
        public ActionResult EditAbout(editwrapper edit)
        {
            try
            {
                using (Datacontext db = new Datacontext())
                {
                    var id = int.Parse(Session["UserID"].ToString());
                    var usr = db.Users.Single(u => u.Id == id);
                    usr.About = edit.About.About;

                    db.SaveChanges();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong, please try again.");
                return View("EditAccount");
            }
            return RedirectToAction("EditAccount");
        }

        [HttpPost]
        public ActionResult EditAge(editwrapper edit)
        {
            try
            {
                using (Datacontext db = new Datacontext())
                {
                    var id = int.Parse(Session["UserID"].ToString());
                    var usr = db.Users.Single(u => u.Id == id);
                    usr.Age = edit.Age.Age;

                    db.SaveChanges();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong, please try again.");
                return View("EditAccount");
            }
            return RedirectToAction("EditAccount");
        }

        [HttpPost]
        public ActionResult EditProfilePic(editwrapper edit)
        {
            try
            {
                using (Datacontext db = new Datacontext())
                {
                    var id = int.Parse(Session["UserID"].ToString());
                    var usr = db.Users.Single(u => u.Id == id);
                    if (edit.ProfileURL.ProfileURL.EndsWith(".jpg") || edit.ProfileURL.ProfileURL.EndsWith(".png") || edit.ProfileURL.ProfileURL.EndsWith(".img"))
                    {
                        usr.PictureURL = edit.ProfileURL.ProfileURL;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Must be a URL from the internet ending with .jpg, .png or .img");
                    }



                    db.SaveChanges();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong, please try again.");
                return View("EditAccount");
            }
            return RedirectToAction("EditAccount");
        }

        [HttpPost]
        public ActionResult EditSearchable(editwrapper edit)
        {
            try
            {
                using (Datacontext db = new Datacontext())
                {
                    var id = int.Parse(Session["UserID"].ToString());
                    var usr = db.Users.Single(u => u.Id == id);
                    usr.Searchable = edit.Searchable.Searchable;

                    db.SaveChanges();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong, please try again.");
                return View("EditAccount");
            }
            return RedirectToAction("EditAccount");
        }
    }
}