using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oopFinalProjecy
{
    public class Books : IBorrowable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; } = true;

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


        #region Borrow() and Return() Methods
        public void Borrow(User user)
        {
            if (!IsAvailable)
            {
                throw new Exception("The book is currently out");
            }

            IsAvailable = false;
            user.MyBooks.Add(this);

            if (user is Student student)
            {
                student.BooksBorrowed++;
            }

            if (user is Teacher teacher)
            {
                teacher.BooksBorrowed++;
            }

        }

        public void Return(User user)
        {
            if (!user.MyBooks.Contains(this))
            {
                MessageBox.Show(
                    $"{user.Name} Did not borrow this book",
                    "Can't Return Book",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
                
            IsAvailable = true;
            user.MyBooks.Remove(this);

            if (user is Student student)
            {
                student.BooksBorrowed--;
            }

            if (user is Teacher teacher)
            {
                teacher.BooksBorrowed--;
            }

        }


        #endregion




    }
}
