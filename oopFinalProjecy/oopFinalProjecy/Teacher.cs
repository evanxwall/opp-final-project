using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopFinalProjecy
{
    internal class Teacher : User
    {
        public int BorrowLimit { get; set; } = 10; // Will default to 10

        public int BooksBorrowed { get; set; } = 0; // Will increase as books are borrowed

        public Teacher()
        {
            // Default, does nothing
        }

        public Teacher(string name, string role)
            : base(name, role) 
        {
            // Overloaded, will Call base
        }

    }
}
