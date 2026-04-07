using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopFinalProjecy
{
    public class Student : User
    {
        public int BorrowLimit { get; set; } = 5; 

        public int BooksBorrowed { get; set; } = 0; 

        public Student()
        {
            
        }

        public Student(string name, string role)
            : base(name, role) 
        {
            
        }

    }
}
