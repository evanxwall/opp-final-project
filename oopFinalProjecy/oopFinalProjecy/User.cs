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

        List<Books> MyBooks { get; set; }

        public User()
        {
            UserId = NewUserID(); // Gives new User a new ID
            MyBooks = new List<Books>(); // Creates a New list of books for user
        }

        public User(string name, string role) : this()
        {
            Name = name; // Sets user name
            Role = role; // Sets user role
        }

        static int NewUserID()
        {
            int i = 0;
            return i + 1;
            // This will be redone in a better
            // non hard coded way later
        }

    }
}
