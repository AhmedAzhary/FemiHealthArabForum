using FemiHealthArabForum.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult AtendeesListing(int? page, string searchText = "")
        {
            int pageSize = 20;
            int pageIndex = page.HasValue ? page.Value : 1;
            ViewBag.searchText = searchText;
            var attendees = new List<Atendee>()
            {
             new Atendee
             {
                 Email = "dasdasd",
                 Name ="hamada kok hamadahamadahamadahamadahamadahamadao",
                 Phone = "4234234",
                 ID ="A1"
             },
             new Atendee
             {
                 Email = "dasdasd",
                 Name ="hamada koko",
                 Phone = "4234234",
                 ID ="A3"
             },new Atendee
             {
                 Email = "dasdasd",
                 Name ="hamada koko",
                 Phone = "4234234",
                 ID ="A4"
             },new Atendee
             {
                 Email = "dasdasd",
                 Name ="hamada koko",
                 Phone = "4234234",
                 ID ="A5"
             },new Atendee
             {
                 Email = "dasdasd",
                 Name ="hamada koko",
                 Phone = "4234234",
                 ID ="A6"
             }
            }; // get from the static list

            if (!string.IsNullOrEmpty(searchText))
            {
                attendees = attendees.Where(att => att.ID == searchText || att.Name.Contains(searchText)).ToList();
            }
            IPagedList<Atendee> atList = attendees.ToPagedList(pageIndex, pageSize);
            return View(atList);
        }
        public ActionResult GetAtendeesListing(int? page, string searchText = "")
        {
            int pageSize = 20;
            int pageIndex = page.HasValue ? page.Value : 1;
            ViewBag.searchText = searchText;
            var attendees = new List<Atendee>()
            {
             new Atendee
             {
                 Email = "dasdasd",
                 Name ="hamada kok hamadahamadahamadahamadahamadahamadao",
                 Phone = "4234234",
                 ID ="A1"
             },
             new Atendee
             {
                 Email = "dasdasd",
                 Name ="hamada koko",
                 Phone = "4234234",
                 ID ="A3"
             },new Atendee
             {
                 Email = "dasdasd",
                 Name ="hamada koko",
                 Phone = "4234234",
                 ID ="A4"
             },new Atendee
             {
                 Email = "dasdasd",
                 Name ="hamada koko",
                 Phone = "4234234",
                 ID ="A5"
             },new Atendee
             {
                 Email = "dasdasd",
                 Name ="hamada koko",
                 Phone = "4234234",
                 ID ="A6"
             }
            }; // get from the static list
            searchText = searchText.ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                attendees = attendees.Where(att => att.ID.ToLower() == searchText || att.Name.ToLower().Contains(searchText.ToLower())).ToList();
            }
            IPagedList<Atendee> atList = attendees.ToPagedList(pageIndex, pageSize);
            return Json(new { PV = RenderViewToString (ControllerContext, "~/Views/Home/_listing.cshtml", atList)}, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            return Json(new { name = ""  }, JsonRequestBehavior.AllowGet);
        }
        private static string RenderViewToString(ControllerContext context, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = context.RouteData.GetRequiredString("action");

            var viewData = new ViewDataDictionary(model);

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(context, viewName);
                var viewContext = new ViewContext(context, viewResult.View, viewData, new TempDataDictionary(), sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }
}