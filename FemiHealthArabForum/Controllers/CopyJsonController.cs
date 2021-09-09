using FemiHealthArabForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FemiHealthArabForum.Controllers
{
    public class CopyJsonController : Controller
    {
        // GET: CopyJson
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MergeJson(string json)
        {
            List<Atendee> newAtendees = new List<Atendee>(); // get it from the json
            // read from the file 
            List<Atendee> recentAtendees = new List<Atendee>(); // get it from the logic 


            return View();
        }
    }
}