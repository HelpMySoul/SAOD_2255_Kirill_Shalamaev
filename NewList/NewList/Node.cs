using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewList
{
    class Node<T>
    {
        public Node(T value)
            {
                this.value = value;
            }
        public T value;
        public Node<T> next;
        public Node<T> previous;
    }
}
