using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopFinalProjecy
{
    internal abstract class User
    {
        string Name { get; set; }

        int UserId { get; set; }

        string Role { get; set; }

        // BookList MyBooks will need to be added here

        public User()
        {
            // Default Constructor, needs to Intialize Name and MyBooks
        }

        public User(string name, int userId)
        {
            // Sends Name and Role only, calls the default
        }



    }
}
