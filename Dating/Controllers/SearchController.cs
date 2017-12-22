using Datalayer;
using Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dating.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search

        public ActionResult Search()
        {
            if (Session["UserID"] != null)
            {
                int currentUser = Convert.ToInt32(Session["UserID"]);
                using (Datacontext db = new Datacontext())
                {
                    var userList = new List<User>();

                    userList = db.Users.ToList();

                    return View(userList);
                }
            }
            return RedirectToAction("Index");

        }

        //public ActionResult Filter(string searchString)

        //{
        //    using (Datacontext db = new Datacontext())
        //    {
        //        var userstring = from m in db.Users
        //                         where m.Searchable.Equals("Yes")
        //                         select m;

        //        if (!String.IsNullOrEmpty(searchString))
        //        {
        //            userstring = userstring.Where(s => s.Firstname.Contains(searchString) || s.Lastname.Contains(searchString));
        //        }

        //        return View();
        //    }

        //}
    }
}