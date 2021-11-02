using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreasTestApp.Areas.Store.Controllers
{
    public class BookController : Controller
    {
        // GET: Store/Book
        public ActionResult Index()
        {
            return View();
        }
    }
}