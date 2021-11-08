using FiltersStudyApp.Filters;
using FiltersStudyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersStudyApp.Controllers
{   [Log]
    public class HomeController : Controller
    {   // [Authorize]

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Log()
        {
            var visitors = new List<Visitor>();
            using (LogContext db = new LogContext())
            {
                visitors = db.Visitors.ToList();
            }
            return View(visitors);
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
    }
}