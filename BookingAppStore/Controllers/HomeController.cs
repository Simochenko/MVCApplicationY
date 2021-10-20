using BookingAppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingAppStore.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            var books = db.Books;
            ViewBag.Message = " Это частичное представление.";
            //ViewBag.Books = books;
            SelectList author = new SelectList(db.Books, "Author", "Name");
            ViewBag.Author = author;
            return View(books);
        }

        public ActionResult GetBook(int id)
        {
            Book b = db.Books.Find(id);
            if (b == null)
                return HttpNotFound();
            return View(b);
        }

        public ActionResult BookIndex()
        {
            var books = db.Books;
            //ViewBag.Books = books;
            return View(books);
        }


        [HttpPost]
        public string GetForm(string[] countries)
        {
            string result = "";
            foreach (string c in countries)
            {
                result += c;
                result += ";";
            }
            return "Вы выбрали: " + result;
        }

        //[HttpPost]
        //public string GetForm(string author)
        //{
        //    return author;
        //}
        //[HttpPost]
        //public string GetForm(string color)
        //{
        //    return color;
        //}

        //[HttpPost]
        //public string GetForm(bool set)
        //{
        //    return set.ToString();
        //}

        public ActionResult GetList()
        {
            string[] states = new string[] { "Russia", "USA", "Canada", "France" };
            //ViewBag.Message = " Это частичное представление.";
            return PartialView(states);
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            Purchase purchase = new Purchase { BookId = id , Person = "Неизвестно"};
            return View(purchase);
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            //добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            //сохаяем в бд все изменения
            db.SaveChanges();
            return "Senks," + purchase.Person + ", за покупку";
        }

        /*public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }*/
    }
}