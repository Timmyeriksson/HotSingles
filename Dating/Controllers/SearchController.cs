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

                    var searchabletrue = from m in db.Users
                                         where m.Searchable == true
                                         select m;

                    foreach (User user in searchabletrue)
                    {
                        userList.Add(user);
                    }

                    return View(userList);
                }
            }
            return RedirectToAction("Index");

        }

        //public ActionResult Search(string searchString, User model)

        //{
        //    using (Datacontext db = new Datacontext())
        //    {
        //        var userstring = from m in db.Users
        //                         where m.Searchable == true
        //                         select m;

        //        if (!string.IsNullOrEmpty(searchString))
        //        {
        //            userstring = userstring.Where(s => s.Firstname.Contains(searchString));
        //        }

        //        return View(userstring);
        //    }

        //}
    }
}