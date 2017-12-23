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

        public ActionResult Filter(string searchString)
        {
            if (Session["UserID"] != null)
            {
                int currentUser = Convert.ToInt32(Session["UserID"]);
                //Lista här? eller nedan
                using (Datacontext db = new Datacontext())
                {
                    //kan behövas instansieras en lista här på något sätt?
                    var userstring = from m in db.Users
                                     where m.Searchable == true
                                     select m;
                    if (!string.IsNullOrEmpty(searchString))
                    {
                        {
                            userstring = userstring.Where(s => s.Firstname.Contains(searchString));
                        }
                        //vid debugging ligger resultaten tydligt i userstring variabeln. men får dem ej vidare därifrån. 
                        //jämför med lista alla så ser man att allt hänger med där rätt smidigt.
                        return View(userstring);

                    }
                }
            }
            return View();
        }
    }
}