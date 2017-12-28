using Datalayer.Entities;
using Datalayer.repository;
using Dating.Models;
using System;
using System.Web.Mvc;

namespace Dating.Controllers
{
    public class RegisterAccountController : StartController
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
                    Password = model.Password,
                    Age = model.Age,
                    Gender = model.Gender,
                    PictureURL = "https://pbs.twimg.com/profile_images/1724449330/stick_man_by_minimoko94-d2zvfn8.png",
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
        }
    }
}