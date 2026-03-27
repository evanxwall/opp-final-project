using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopFinalProjecy
{
    internal class Teacher : User
    {
        int BorrowLimit = 10; // Will default to 10

        int BooksBorrowed = 0; // Will increase as books are borrowed

        public Teacher()
        {
            // Default, does nothing
        }

        public Teacher(int br)
        {
            // Overloaded, will Call base
        }



    }
}
