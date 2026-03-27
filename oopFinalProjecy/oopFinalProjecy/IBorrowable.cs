using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopFinalProjecy
{
    internal interface IBorrowable
    {
        void Borrow(User user); // Doesnt Return Anything
        void Return(User user); // Doesnt Return Anything
    }
}
