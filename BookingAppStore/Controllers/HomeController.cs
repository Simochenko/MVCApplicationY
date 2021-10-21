using BookingAppStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        [HttpGet]
        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            db.Books.Add(book); // insert
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            db.Books.Add(book); // insert
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //public ActionResult Delete(int id)
        //{
        //    Book b = db.Books.Find(id);
        //    if (b != null)
        //    {
        //        db.Books.Remove(b); //DELETE
        //        db.SaveChanges();
        //    }
        //    //Book b = new Book { Id = id };
        //    //db.Entry(b).State = EntityState.Deleted;
        //    //db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            Book b = db.Books.Find(id);
            if(b == null)
            {
                return HttpNotFound();
            }
            db.Books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditBook(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = db.Books.Find(id);
            if (book != null)
            {
                return View(book);
            }
            return HttpNotFound();
        }
        [HttpPost]

        public ActionResult EditBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified; //UPDATE
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = db.Books.Find(id);
            if(book != null)
            {
                return View(book);
            }
            return HttpNotFound();
        }
        [HttpPost]

        public ActionResult Edit(Book book)
        {
            db.Entry(book).State = EntityState.Modified; //UPDATE
            db.SaveChanges();
            return RedirectToAction("Index");
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