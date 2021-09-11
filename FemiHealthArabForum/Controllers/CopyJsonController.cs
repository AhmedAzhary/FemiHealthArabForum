using FemiHealthArabForum.Models;
using Newtonsoft.Json;
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

                List<Atendee> newAtendees = JsonConvert.DeserializeObject<List<Atendee>>(json); // get it from the json
                                                                                                // read from the file 
                string jsonInput = System.IO.File.ReadAllText(Server.MapPath("~/JsonData/AttendeesJson.json"));
                List<Atendee> recentAtendees = JsonConvert.DeserializeObject<List<Atendee>>(jsonInput);// get it from the logic 

                var newJson = new List<Atendee>();
                HashSet<string> idS = new HashSet<string>();
                for (int i = 0; i < newAtendees.Count; i++)
                {
                    if (!idS.Contains(newAtendees[i].ID)){
                        newJson.Add(new Atendee
                        {
                            Email = newAtendees[i].Email,
                            Name = newAtendees[i].Name,
                            Phone = newAtendees[i].Phone,
                            ID = newAtendees[i].ID
                        });
                    }
                    idS.Add(newAtendees[i].ID);
                }

                for (int i = 0; i < recentAtendees.Count; i++)
                {
                    if (!idS.Contains(recentAtendees[i].ID))
                    {
                        newJson.Add(new Atendee
                        {
                            Email = recentAtendees[i].Email,
                            Name = recentAtendees[i].Name,
                            Phone = recentAtendees[i].Phone,
                            ID = recentAtendees[i].ID
                        });
                    }
                    idS.Add(recentAtendees[i].ID);
                }
                string jsonNew = JsonConvert.SerializeObject(newAtendees.ToArray());

                //write string to file
                System.IO.File.WriteAllText(Server.MapPath("~/JsonData/AttendeesJson.json"), jsonNew);
                // desirialize the list into json file
                return Json(new { JsonRequestBehavior.AllowGet });
            }
            catch (Exception e)
            {
                return Json(new { Message = e.Message, JsonRequestBehavior.AllowGet });
            }

        }
    }
}