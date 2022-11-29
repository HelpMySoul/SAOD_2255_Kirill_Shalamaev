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
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _arr.GetEnumerator();
        }
        public MyHash(int size)
        {
            _arr = new List<Node<Key, T>>[size];
            for (int i = 0; i != size; i++)
            {
                _arr[i] = new List<Node<Key, T>> { };
            }
        }
        public List<Node<Key, T>> this[int index]
        {
            get => _arr[index];
            set => _arr[index] = value;
        }
        int Count
        {
            get
            {
                return _arr.Length;
            }
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
            Node<Key, T> NewNode = new Node<Key, T>(value, k, HashFunction(k));
            return NewNode;
        }
        public Node<Key,T> Find(Key k)
        {
            Node<Key, T> result = null;
            foreach (Node<Key,T> n in _arr[HashFunction(k)])
            {
                if (k.Equals(n.Key))
                {
                    result = n;
                    break;
                }
            }
            if (result == null)
            {
                throw new Exception("Нет элемента");
            }
            return result;
        }
        public void Delete(Key k)
        {
            try
            {
                _arr[HashFunction(k)].Remove(Find(k));
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
                return k.GetHashCode() % Count;
            }           
        }
        public Dictionary<Key, T> GetDic()
        {
            Dictionary<Key, T> result = new Dictionary<Key, T> { };
            foreach (List<Node<Key, T>> l in _arr)
            {
                foreach(Node<Key, T> n in l)
                {
                    result.Add(n.Key, n.Value);
                }
            }
            return result;
        }
    }
}
