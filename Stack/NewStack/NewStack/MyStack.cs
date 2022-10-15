using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewStack
{
    class MyStack<T>
    {
        private T[] arr; 
        private int count;
        public MyStack(int size)
        {
            arr = new T[size];
        }
        public T Pop()
        {
            if (count == 0)
            {
                throw new IndexOutOfRangeException();
            }
            return arr[--count];

        }
        public T Top()
        {
            if (count == 0)
            {
                throw new IndexOutOfRangeException();
            }
            return arr[count-1];
        }
        public void Push(T value)
        {
            if (count+1 == arr.Length)
            {
                throw new IndexOutOfRangeException();
            }
            arr[count++] = value;
        }
        public T[] ToArray()
        {
            T[] result = new T[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = arr[i];
            }
            return result;
        } 
    }
}
