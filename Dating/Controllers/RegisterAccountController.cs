using Datalayer.Entities;
using Datalayer.repository;
using Dating.Models;
using System;
using System.Web.Mvc;

namespace Dating.Controllers
{
    public class RegisterAccountController : Controller
    {

        private Repository databas = new Repository();


        // GET: RegisterAccount
        public ActionResult RegisterAccount()
        {

            return View();
        }

        [HttpPost]
        public ActionResult RegisterAccount(RegisterAccount model)
        {

            try
            {
                var user = new User
                {
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Email = model.Email,
                    Password= model.Password,
                    Age = model.Age,
                    Gender = model.Gender,
                    PictureURL = model.PictureURL,
                    Searchable = model.Searchable

                };

                databas.addUser(user);
                databas.saveUser();
                return RedirectToAction("LogInView", "Login");
            }
            catch (Exception)
            {

                throw;
            }


            return View();
        }
    }
}