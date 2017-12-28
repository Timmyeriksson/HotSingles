using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dating.Controllers
{
    public class CustomErrorController : Controller
    {
        // GET: CustomError
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PageNotFound()
        {
            return View();
        }

        public ActionResult InternalServerError()

        {
            return View();
        }

        public ActionResult UnspecifiedError()
        {
            return View();
        }
    }
}