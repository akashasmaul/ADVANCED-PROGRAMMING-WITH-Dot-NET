using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Education()
        {
            ViewBag.Message = "My Educational Information";

            return View();
        }

        public ActionResult Projects()
        {
            ViewBag.Message = "My Project Information";

            return View();
        }

        public ActionResult personal_Info()
        {
            ViewBag.Message = "My Information";

            return View();
        }

        public ActionResult Ref()
        {
            ViewBag.Message = "Reference";

            return View();
        }
    }
}