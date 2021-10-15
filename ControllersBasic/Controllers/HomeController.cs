using ControllersBasic.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace ControllersBasic.Controllers
{
    public class HomeController : Controller
    {
        public string GetData()
        {
            string id = HttpContext.Request.Cookies["id"].Value;
            var val = Session["name"];
            return val.ToString();
        }

        public ActionResult Index()
        {
            //ViewData["Head"] = "Привет VIEW!!!";
            Session["name"] = "Tom";

            HttpContext.Response.Cookies["id"].Value = "ca-4353w";
            ViewBag.Head = "Привет VIEW!!!";
            ViewBag.Fruit = new List<string>
            {
                "яблоки", "груши", "вишни"
            };
            return View();  //"~/Views/Some/Index.cshtml"
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult GetImage()
        {
            string path = "../Content/Images/visual_studio.jpg";
            return new ImageResult(path);
        }

        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2> Hello world!!!</h2>");
        }

        [HttpGet]
        public ActionResult GetBook()
        {
            return View();
        }
        [HttpPost]
        public string PostBook()
        {
            string title = Request.Form["title"];
            string author = Request.Form["author"];
            return title + " " + author;
        }

        public string Square()
        {
            int a = Int32.Parse(Request.Params["a"]);
            int h = Int32.Parse(Request.Params["h"]);
            double s = a * h / 2;
            return "<h2>Площадь треугольника с основанием " + a + " и высотой " + h + " равна " + s + "</h2>";
        }

        public string GetId(int id)
        {
            return id.ToString();
        }
        /*  public ActionResult GetVoid(int id)
          {
              if(id > 3)
              {
                  return Redirect("/Home/Contact");
              }
              return View("About");
          }

        public ActionResult GetVoid(int id)
        {
            if (id > 3)
            {
                return RedirectToRoute(new { controller = "Home", action = "Contact" });
            }
            return View("About");
        }*/

        public ActionResult GetVoid(int id)
        {
            if (id > 3)
            {
                //return RedirectToAction("Square","Home", new{a = 10, h = 12 });
                //return new HttpStatusCodeResult(404);
                //return HttpNotFound();
                return new HttpUnauthorizedResult();
            }
            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public FilePathResult GetFile()
        {
            // путь к файлу
            string file_path = Server.MapPath("~/Files/order.pdf");
            // тип файла - сontent-type
            string file_type = "application/octet-stream";   //octet-stream  -любой формат
            // имя файла не обязательно
            string file_name = "order.pdf";
            return File(file_path, file_type, file_name);
        }

        public FileContentResult GetBytes()
        {
            // путь к файлу
            string path = Server.MapPath("~/Files/order.pdf");
            byte[] mas = System.IO.File.ReadAllBytes(path);
            // тип файла - сontent-type
            string file_type = "application/pdf";
            // имя файла не обязательно
            string file_name = "order.pdf";
            return File(mas, file_type, file_name);
        }

        public FileStreamResult GetStream()
        {
            // путь к файлу
            string path = Server.MapPath("~/Files/order.pdf");
            FileStream fs = new FileStream(path, FileMode.Open);
            // тип файла - сontent-type
            string file_type = "application/pdf";
            // имя файла не обязательно
            string file_name = "order.pdf";
            return File(fs, file_type, file_name);
        }

        public string GetContext()
        {
            Response.Write("Hello World!!!"); // HttpContext.Response.Write("Hello World!!!");
            string browser = Request.Browser.Browser; //string browser = HttpContext.Request.Browser.Browser;
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
            return "<p>Browser: " + browser + "</p><p>User-Agent: " + user_agent + "</p><p>Url запроса: " + url + "</p><p>Referrer: " + referrer + "</p><p>Ip адрес: " + ip + "</p>";
        }

    }
}