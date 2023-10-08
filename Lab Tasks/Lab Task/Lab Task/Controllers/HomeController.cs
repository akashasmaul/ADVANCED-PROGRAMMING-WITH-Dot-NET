using Lab_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_Task.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Form()
        {
            ViewBag.Message = "Invalid";

            return View();
        }

        [HttpPost]
        public ActionResult Form(Form s)
        {
            if (ModelState.IsValid)
            {
                TempData["FormData"] = s;
                return RedirectToAction("Form");
            }
            return View(s);
        }


    }
}