using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace DataAnnotationsApp.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }        
    }

    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "Война и мир", Author = "Л. Толстой", Year = 2200 });
            db.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", Year = 1800 });
            db.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Year = 1500 });

            base.Seed(db);
        }
    }
}