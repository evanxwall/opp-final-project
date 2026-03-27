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




    }
}
