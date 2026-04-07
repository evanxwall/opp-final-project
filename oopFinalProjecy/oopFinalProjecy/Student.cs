using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopFinalProjecy
{
    public class Student : User
    {
        public int BorrowLimit { get; set; } = 5; // Will default to 5

        public int BooksBorrowed { get; set; } = 0; // Will increase as books are borrowed

        public Student()
        {
            // Default
        }

        public Student(string name, string role)
            : base(name, role) // UserID is not needed since this will call base constructor which generates one
        {
            // BorrowLimit and Booksborrowed already have defaults so no need to called them here
        }

    }
}
