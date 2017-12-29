using Datalayer;
using Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Dating.Controllers
{
    public class HomeController : StartController
    {
        [HandleError]
        public ActionResult Index()
        {
            using (Datacontext db = new Datacontext())
            {
                List<User> randomListan()
                {

                    var list = new List<User>();
                    var randomUser = db.Users.Where(x => x.Searchable == true).OrderBy(x => Guid.NewGuid()).ToList();

                    list.Add(randomUser[0]);
                    list.Add(randomUser[1]);
                    list.Add(randomUser[2]);


                    return list;
                }
                return View(randomListan());
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}