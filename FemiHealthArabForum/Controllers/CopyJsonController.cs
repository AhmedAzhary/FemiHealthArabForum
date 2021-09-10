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
            try
            {
                string userName = System.Configuration.ConfigurationManager.AppSettings["IDStartValue"];

                List<Atendee> newAtendees = new List<Atendee>(); // get it from the json
                                                                 // read from the file 
                List<Atendee> recentAtendees = new List<Atendee>(); // get it from the logic 

                var newJson = new List<Atendee>();
                int id = 0;
                for (int i = 0; i < newAtendees.Count; i++)
                    newJson.Add(new Atendee
                    {
                        Email = newAtendees[i].Email,
                        Name = newAtendees[i].Name,
                        Phone = newAtendees[i].Phone,
                        ID = newAtendees[i].ID
                    });

                for (int i = 0; i < recentAtendees.Count; i++)
                    newJson.Add(new Atendee
                    {
                        Email = newAtendees[i].Email,
                        Name = newAtendees[i].Name,
                        Phone = newAtendees[i].Phone,
                        ID = newAtendees[i].ID
                    });

                // desirialize the list into json file
                return Json(new { JsonRequestBehavior.AllowGet });
            }
            catch(Exception e)
            {
                return Json(new { Message = e.Message, JsonRequestBehavior.AllowGet });
            }

        }
    }
}