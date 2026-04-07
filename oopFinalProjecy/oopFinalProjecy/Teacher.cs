using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopFinalProjecy
{
    public class Teacher : User
    {
        public int BorrowLimit { get; set; } = 10; 
        public int BooksBorrowed { get; set; } = 0; 

        public Teacher()
        {
            // Default
        }

        public Teacher(string name, string role)
            : base(name, role) 
        {
            // Overloaded, Calls Base
        }

    }
}
