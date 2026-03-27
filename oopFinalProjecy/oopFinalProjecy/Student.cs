using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopFinalProjecy
{
    internal class Student : User
    {
        int BorrowLimit = 5; // Will default to 5

        int BooksBorrowed = 0; // Will increase as books are borrowed

        public Student()
        {
            // Default, does nothing
        }

        public Student(int br)
        {
            // Overloaded, will Call base
        }

    }
}
