using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutesApp.Controllers
{
    public class BookController : Controller
    {
        // GET: Book/index
        public string Index(string author, int id)
        {
            return author + " " + id.ToString();
        }
    }
}