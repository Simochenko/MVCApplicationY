using ModelBinderApp.Binders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinderApp.Models
{
    //[ModelBinder(typeof(BookModelBinder))]
    //[Bind(Exclude = "Year")]
    public class Book
    {   [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Автор")]
        public string Author { get; set; }
        [Display(Name = "Год")]
        public int Year { get; set; }
    }
}