using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopFinalProjecy
{
    internal class Books
    {
        string Title { get; set; }

        string Author { get; set; }
        bool IsAvailable { get; set; } // Will default to true

        public Books()
        {
            // Default Constructor
        }

        public Books(string title, string author, bool isAvailable)
        {
            // Overloaded
            Title = title;
            Author = author;
            IsAvailable = isAvailable;
        }


        // These Aren't Completely Right but just wanted a template down
        public static Books operator ==(Books book1,  Books book2)
        {
            return book1 == book2;
        }

        public static Books operator !=(Books book1, Books book2)
        {
            return book1 != book2;
        }

    }
}
