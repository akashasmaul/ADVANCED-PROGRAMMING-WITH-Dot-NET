using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Company_Website.Models
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()

        {
            Company c = new Company();
            return View();
        }

        public ActionResult Project() {
            var p1 = new Project()
            {

            };
            return View();
        }
    }

   
}