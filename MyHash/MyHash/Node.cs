using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHash
{
    public class Node<K, T>
    {
        public T Value { get; set; }
        public K Key { get; }
        public int HashKey { get; }
        public Node(T value, K key, int hash)
        {
            Value = value;
            Key = key;
            HashKey = hash;
        }
    }
}
