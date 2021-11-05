using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ValidationApp.Models;

namespace ValidationApp.Annotations
{
    public class NotAllowedAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Book book = value as Book;
            if (book.Author == "Л. Толстой" && book.Year > 1910)
            {
               return false;
            }
            return true;
        }
    }
}