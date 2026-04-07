using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopFinalProjecy
{
    public abstract class User
    {
        public string Name { get; set; }

        public int UserId { get; set; }

        public string Role { get; set; }

        public List<Books> MyBooks { get; set; }

        // Default
        public User()
        {
            UserId = NewUserID(); 
            MyBooks = new List<Books>(); 
        }

        // Overloaded, Calls Base
        public User(string name, string role) : this()
        {
            Name = name; 
            Role = role; 
        }

        static int NewUserID()
        {
            int i = 0;
            return i + 1;
        }

    }
}
