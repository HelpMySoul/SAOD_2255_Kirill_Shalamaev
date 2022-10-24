using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class QueueExeption : Exception
    {
        public QueueExeption() { }

        public QueueExeption(string message)
                : base(message) { }
    }
}
