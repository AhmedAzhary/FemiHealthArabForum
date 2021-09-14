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
        AtendeeLogic logic = new AtendeeLogic();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AtendeesManagment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAtendee(string name, string phone, string email)
        {

            if (!Directory.Exists(Server.MapPath("~/JsonData")))
            {
                Directory.CreateDirectory(Server.MapPath("~/JsonData"));
                System.IO.File.WriteAllText(Server.MapPath("~/JsonData/AttendeesJson.json"), null);
            }
            string id = logic.AddAttendee(new Atendee()
            {
                Name = name,
                Phone = phone,
                Email = email
            }, Server.MapPath("~/JsonData/AttendeesJson.json"));

            return Json(new { name = name, id = id }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Export()
        {
            if (!Directory.Exists(Server.MapPath("~/JsonData")))
            {
                Directory.CreateDirectory(Server.MapPath("~/JsonData"));
                System.IO.File.WriteAllText(Server.MapPath("~/JsonData/AttendeesJson.json"), null);
            }

            if (!Directory.Exists(Server.MapPath("~/JsonData")))
            {
                Directory.CreateDirectory(Server.MapPath("~/JsonData"));
                System.IO.File.WriteAllText(Server.MapPath("~/JsonData/AttendeesExcel.json"), null);
            }
            logic.ExportToExcel(Server.MapPath("~/JsonData/AttendeesJson.json"), Server.MapPath("~/JsonData/AttendeesExcel.xlsx"));
            return Json(new { val = true }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AtendeesListing(int? page, string searchText = "")
        {
            int pageSize = 10;
            int pageIndex = page.HasValue ? page.Value : 1;
            ViewBag.searchText = searchText;
            if (AtendeeLogic.attendees.Count == 0)
                logic.FillArray(Server.MapPath("~/JsonData/AttendeesJson.json"));
            var attendees = AtendeeLogic.attendees;

            if (!string.IsNullOrEmpty(searchText))
            {
                attendees = attendees.Where(att => att.ID == searchText || att.Name.Contains(searchText)).ToList();
            }
            IPagedList<Atendee> atList = attendees.ToPagedList(pageIndex, pageSize);
            return View(atList);
        }
        public ActionResult GetAtendeesListing(int? page, string searchText = "")
        {
            int pageSize = 5;
            int pageIndex = page.HasValue ? page.Value : 1;
            ViewBag.searchText = searchText;
            if (AtendeeLogic.attendees.Count == 0)
                logic.FillArray(Server.MapPath("~/JsonData/AttendeesJson.json"));
            var attendees = AtendeeLogic.attendees;
            searchText = searchText.ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                attendees = attendees.Where(att => att.ID.ToLower().Contains(searchText)   || att.Name.ToLower().Contains(searchText.ToLower())).ToList();
            }
            IPagedList<Atendee> atList = attendees.ToPagedList(pageIndex, pageSize);
            return Json(new { PV = RenderViewToString(ControllerContext, "~/Views/Home/_listing.cshtml", atList) }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var name = AtendeeLogic.attendees.Where(at => at.ID == id).Select(t => t.Name).FirstOrDefault();
            logic.Delete(id, Server.MapPath("~/JsonData/AttendeesJson.json"));
            return Json(new { name = name }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Print(string name, string id)
        {
            ViewBag.Name = name;
            ViewBag.ID = id;
            return View();
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