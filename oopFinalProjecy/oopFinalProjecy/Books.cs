using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopFinalProjecy
{
    internal class Books : IBorrowable
    {
        string Title { get; set; }
        string Author { get; set; }
        bool IsAvailable { get; set; } = true;

        public Books()
        {
            // Default
        }

        public Books(string title, string author)
        {
            // Overloaded
            Title = title;
            Author = author;
        }

        public static bool operator ==(Books book1,  Books book2)
        {
            if (ReferenceEquals(book1, book2)) 
                return true;

            if (book1 is null || book2 is null) 
                return false;

            return book1.Title == book2.Title && book1.Author == book2.Author;
        }

        public static bool operator !=(Books book1, Books book2)
        {
            return !(book1 == book2);
        }

        public void Borrow(User user) => IsAvailable = false;
        public void Return(User user) => IsAvailable = true;

    }
}
