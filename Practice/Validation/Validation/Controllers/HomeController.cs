using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validation.Models;

namespace Validation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            ViewBag.Message = "Invalid";

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignUp s)
        {
            if (ModelState.IsValid)
            {
                TempData["SignUpData"] = s;
                return RedirectToAction("Profile");
            }
            return View(s);
        }

        public ActionResult Profile()
        {
            var s = TempData["SignUpData"] as SignUp;
            if (s == null)
            {
                // Handle the case where no SignUp data is found
                return RedirectToAction("SignUp");
            }
            return View(s);
        }
    }
}