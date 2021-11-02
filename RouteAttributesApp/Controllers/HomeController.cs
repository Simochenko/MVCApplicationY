using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RouteAttributesApp.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Route("Account")]
        public ActionResult Index() //Home/Index/  //My/Account
        {
            return View();
        }

        //2/name
       // [Route("{id:int}/{name:length(5)}")]
        [Route("{id:int}/{name=volga}")]
        public string Test(int id, string name)
        {
            return id.ToString() + ". " + name;
        }

        [Route("~/lol/twit/{id:int}")]
        public string Twit(int id)
        {
            return id.ToString();
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