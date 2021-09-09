using FemiHealthArabForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FemiHealthArabForum.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AtendeesManagment()
        {
            return View();
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

        [HttpPost]
        public ActionResult SaveAtendee(Atendee atendee)
        {
            // read the objects from Json file as List<Atendee> "desirialization"

            // Append the new one 

            // serialize the List<Atendee>

            // save file again "Serialization"

            return View();
        }
        /*Azhary section tmam wala eh ra2ik? */

        /*Sara section  */
        //public ActionResult AddAtendee(){}

        
    }
}