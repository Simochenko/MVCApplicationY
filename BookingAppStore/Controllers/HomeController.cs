﻿using BookingAppStore.Models;
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
            ViewBag.Books = books;
            return View();
        }


        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;

            return View();
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