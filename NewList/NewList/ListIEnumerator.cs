using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewList
{
    partial class NewList<T> 
    {
        private class ListIEnumerator : IEnumerator
        {
            NewList<T> list;
            public ListIEnumerator(NewList<T> list)
            {
                this.list = list;
            }
            private int position = -1;

            public bool MoveNext()
            {
                position++;
                return (position < list.ToArray().Length);
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
                        return list[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }    
}
