using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewList
{
    class ListIEnumerator<T> : IEnumerator
    {
        public T[] _newlist;
        int position = -1;
        public ListIEnumerator(T[] list)
        {
            _newlist = list;
        }
        public bool MoveNext()
        {
            position++;
            return (position < _newlist.Length);
        }
        public void Reset()
        {
            position = -1;
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public T Current
        {
            get
            {
                try
                {
                    return _newlist[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
