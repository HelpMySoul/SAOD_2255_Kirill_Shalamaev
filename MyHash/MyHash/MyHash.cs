using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHash
{
    class MyHash<Key, T> : IEnumerable
    {
        List<Node<Key, T>>[] _arr;
        public IEnumerator GetEnumerator() 
        {
            return new HashEnumerator<Key, T>(_arr);
        }
        public MyHash(int size)
        {
            _arr = new List<Node<Key, T>>[size];
            for (int i = 0; i != size; i++)
            {
                _arr[i] = new List<Node<Key, T>> { };
            }
        }
        public T this[Key key] 
        {
            get => Find(key);
        }
        int Count
        {
            get {
                Console.WriteLine(_arr.Length);
                return _arr.Length; }
        }

        public void Add(Key k, T value)
        {
            foreach (Node<Key, T> Node in _arr[HashFunction(k)])
            {
                if (Node.Key.Equals(k))
                {
                    Node.Value = value;
                    return;
                }
            }
            _arr[HashFunction(k)].Add(CreateNode(k, value));
        }
        Node<Key,T> CreateNode(Key k, T value)
        {
            return new Node<Key, T>(value, k, HashFunction(k));     
        }
        public T Find(Key k)
        {
            foreach (Node<Key,T> n in _arr[HashFunction(k)])
            {
                if (k.Equals(n.Key))
                {
                    return n.Value;
                }
            }
            throw new Exception("Нет элемента");
        }
        public Node<Key, T> FindNode(Key k)
        {
            foreach (Node<Key, T> n in _arr[HashFunction(k)])
            {
                if (k.Equals(n.Key))
                {
                    return n;
                }
            }
            throw new Exception("Нет элемента");
        }
        public void Delete(Key k)
        {
            try
            {
                _arr[HashFunction(k)].Remove(FindNode(k));
            }
            catch
            {
                throw new Exception("Нет элемента");
            }
            
        }
        int HashFunction(Key k)
        {
            
            try
            {
                return Convert.ToInt32(k) % Count;
            }
            catch
            {
                return Math.Abs( k.GetHashCode() % Count);
            }           
        }
        public Dictionary<Key, T> GetDic()
        {
            Dictionary<Key, T> result = new Dictionary<Key, T> { };
            foreach (List<Node<Key, T>> list in _arr)
            {
                foreach(Node<Key, T> n in list)
                {
                    result.Add(n.Key, n.Value);
                }
            }
            return result;
        }
    }
}
