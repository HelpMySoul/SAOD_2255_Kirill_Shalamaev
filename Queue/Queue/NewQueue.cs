using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class NewQueue<T>
    {
        public int Capacity
        {
            get { return arr.Length; }
        }
        public NewQueue(int size)
        {
            arr = new T[size];
        }
        private T[] arr;
        int indOut, indIn, count;
        public void Enqueue(T value)
        {
            if (count != arr.Length)
            {
                arr[indIn] = value;
                indIn++;
                if (indIn == arr.Length)
                {
                    indIn = 0;
                }
                count++;
            }
            else
            {
                throw new QueueExeption("Слишком много элементов");
            }
        }
        public T Dequeue() 
        {
            if (count > 0)
            {
                T result = arr[indOut];
                
                indOut++;
                if (indOut == arr.Length)
                {
                    indOut = 0;
                }
                count--;
                return result;
            }
            else
            {
                throw new QueueExeption("Нет возвращаемого значения");
            }
            
        }
        public T Peek()
        {
            if (count > 0)
            {
                return arr[indOut];
            }
            else
            {
                throw new QueueExeption("Нет элементов");
            }
        }
        public T[] ToArray()
        {
            T[] result = new T[count];
            int fori = count;
            int index = indOut;
            int i = 0;
            while (fori != 0)
            {
                result[i] = arr[index];
                index++;
                if (index == arr.Length)
                {
                    index = 0;
                }
                fori--;
                i++;
            }
            return result;
        }
    }
}
