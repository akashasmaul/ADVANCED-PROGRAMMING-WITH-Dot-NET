using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Company_Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            ViewBag.Message = "Company Website";
            ViewBag.Name = "Elite Solution";
            ViewBag.Address = "Progati Saroni, Baridhara, Dhaka, 1240";
            ViewBag.Desc = "Elite Solution is a leading software company that specializes in delivering innovative and cutting-edge software solutions to businesses of all sizes. We are dedicated to providing high-quality software products and services to meet the unique needs of our clients.";
            ViewBag.Email = "info@elitesolution.com";
            return View();

        }

        public ActionResult Projects()
        {

            Dictionary<string, string> projectDictionary = new Dictionary<string, string>();

            // Add some sample data to the dictionary
            projectDictionary.Add("Elite Shopping", "Rapid Action Ltd");
            projectDictionary.Add("School Mangement System", "Notun High School");
            projectDictionary.Add("Rapid Care", "ABC Hospital");

            // Store the dictionary in ViewBag
            ViewBag.Projects = projectDictionary;

            return View();

        }

        public ActionResult Team()
        {
            // Create an array of team members' names
            string[] teamMembers = new string[]
            {
        "Asmaul Hossain Akash",
        "Avro Alen",
        "Alyssa Siera",
        "Sarah Williams"
                // Add more names as needed
            };

            // Store the array in ViewBag
            ViewBag.TeamMembers = teamMembers;

            return View();
        }



    }
}