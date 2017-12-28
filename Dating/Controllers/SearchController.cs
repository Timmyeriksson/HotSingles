using Datalayer;
using Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dating.Controllers
{
    public class SearchController : StartController
    {
        // GET: Search

        public ActionResult Search(string searchString)
        {
            if (Session["UserID"] != null)
            {
                int currentUser = Convert.ToInt32(Session["UserID"]);
                using (Datacontext db = new Datacontext())
                {
                    var userList = new List<User>();

                    if (searchString == null)
                    {
                        var searchabletrue = from m in db.Users
                                             where m.Searchable == true
                                             select m;
                        foreach (User user in searchabletrue)
                        {
                            userList.Add(user);
                        }
                    }
                    else
                    {
                        var searchabletrue = from m in db.Users
                                             where m.Searchable == true
                                             && (m.Firstname.Contains(searchString)
                                             || m.Lastname.Contains(searchString))
                                             select m;

                        foreach (User user in searchabletrue)
                        {
                            userList.Add(user);
                        }
                    }

                    return View(userList);
                }
            }
            return RedirectToAction("Index");

        }
    }
}