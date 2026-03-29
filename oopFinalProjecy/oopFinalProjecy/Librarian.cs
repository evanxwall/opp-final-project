using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopFinalProjecy
{
    internal sealed class Librarian : User
    {
        public Librarian()
        {
            // Default, does nothing
        }

        public Librarian(string name, string role)
            : base(name, role) 
        {
            // Overloaded, will just call base.
        }

    }
}
