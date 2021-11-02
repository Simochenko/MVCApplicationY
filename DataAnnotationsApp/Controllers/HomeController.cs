using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAnnotationsApp.Models;

namespace DataAnnotationsApp.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            LogModel logModel = new LogModel { Login = "fffff", Password = "PPPPP" };
            return View(logModel);
        }
        public ActionResult Details()
        {
            var book = db.Books.FirstOrDefault();
            return View(book);
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