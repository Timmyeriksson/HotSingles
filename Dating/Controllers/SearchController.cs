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

        public ActionResult Search(string searchString)
        {
            if (Session["UserID"] != null)
            {
                int currentUser = Convert.ToInt32(Session["UserID"]);
                using (Datacontext db = new Datacontext())
                {
                    var userList = new List<User>();

                    //Tar ut alla sökbara användare ifall man inte valt att skicka in en sträng
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
                    //Annars matchar man sökbara med söksträng
                    else
                    {
                        var searchabletrue = from m in db.Users
                                             where m.Searchable == true
                                             && (m.Firstname.Contains(searchString)
                                             || m.Lastname.Contains(searchString))
                                             select m;
                        //Lägger till användarna i en lista som vi sedan presenterar
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