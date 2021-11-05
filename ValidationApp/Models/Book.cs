using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ValidationApp.Annotations;

namespace ValidationApp.Models
{
    //[NotAllowed(ErrorMessage = "Недопустимая книга")]
    public class Book
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        //[Required(ErrorMessage ="Поле должно быть установлено")] // обязательно нужно заполнить поле
        //[StringLength(10, MinimumLength=3, ErrorMessage ="недопустимая длинна")]
        //[Remote("CheckName", "Home", ErrorMessage =" Некоректное название")]
        public string Name { get; set; }

        [Display(Name = "Автор")]
        //[Required]
        //[ValidAuthor(new string[] { "Л. Толстой", "А. Пушкин", "Ф. Достоевский", "И. Тургенев" }, ErrorMessage = "Недопустимый автор")]
        public string Author { get; set; }

        [Display(Name = "Год")]
        //[Required]
        //[Range(1800,2000, ErrorMessage ="Недопустимый год!!!")]
        public int Year { get; set; }
    }

    public class LoginModel
    {   
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        public string Password { get; set; }
    
        public string PasswordConfirm { get; set; }
    }

}