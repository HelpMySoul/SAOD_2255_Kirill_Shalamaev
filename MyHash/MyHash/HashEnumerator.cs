using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHash 
{
    class HashEnumerator<Key, T> : IEnumerator
    {
        List<Node<Key, T>>[] _arr;
        int HashPos = 0;
        int ListPos = -1;
        public HashEnumerator(List<Node<Key, T>>[] _arr) => this._arr = _arr;
        public object Current
        {
            get
            {
                return _arr[HashPos][ListPos];
            }
        }
        public bool MoveNext()
        {
            ListPos++;
            if (ListPos == _arr[HashPos].Count + 1)
            {
                ListPos = 0;
                if (HashPos != _arr.Length)
                {
                    HashPos++;
                    while (_arr[HashPos].Count == 0)
                    {
                        HashPos++;
                        if (HashPos == _arr.Length +1)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;

        }
        public void Reset()
            {
                HashPos = 0;
                ListPos = -1;
            }
    }
}
