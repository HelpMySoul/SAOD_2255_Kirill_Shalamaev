using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewList
{
    class ListExeption : Exception
    {
        public ListExeption() { }

        public ListExeption(string message)
                : base(message) { }
    }
}
