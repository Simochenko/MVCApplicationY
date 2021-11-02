using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DataAnnotationsApp.Models
{
    public class Book
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Название книги")]
        [UIHint("Url")]
        public string Name { get; set; }
        [Display(Name = "Автор")]
        public string Author { get; set; }
        [Display(Name = "Год изнания")]
        public int Year { get; set; }
    }
    public class LogModel
    {
        public string Login { get; set; }
       // [DataType(DataType.Password)]
       [UIHint("Password")]
        public string Password { get; set; }
    }
}