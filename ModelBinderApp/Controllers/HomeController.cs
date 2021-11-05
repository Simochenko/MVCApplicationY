using ModelBinderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinderApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            Book b = new Book { Id = 2, Name = "Война и мир", Author = "Л. Толстой", Year = 1862 };
            return View(b);
        }
        [HttpPost]

    
        public String Edit(Book b)
        {
            return "Name: " + b.Name + "<br> Author: " + b.Author + "<br>Year: " + b.Year;
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        //public String Create([Bind(Include ="Name, Author")]Book b)
        public String Create(Book b)
        {
            return "Name: " + b.Name + "<br> Author: " + b.Author + "<br>Year: " + b.Year;
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