using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewList
{
    partial class NewList<T> : IEnumerable
    {
        Node<T> first = null;
        Node<T> last = null;
        public int Count
        {
            get;
            set;
        }
        public Func<Node<T>, bool> SortRule
        {
            get;
            set;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ListIEnumerator(this);
        }

        public T this[int index]
        {
            get => FindNodeByIndex(index).value;
            set { FindNodeByIndex(index).value = value; }
        }

        public void Append(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (first == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.next = newNode;
                newNode.previous = last;
                last = newNode;
            }
            Count++;
        }
        public void Prepend(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (first == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                first.previous = newNode;
                newNode.next = first;
                first = newNode;
            }
            Count++;
        }
        public void Insert(int index, T value)
        {
            if (index < 0 || index > Count - 1)
            {
                throw new ListExeption("Неверный индекс");
            }
            if (index == 0)
            {
                Prepend(value);
            }
            else if (index == Count)
            {
                Append(value);
            }
            else
            {
                Node<T> newNode = new Node<T>(value);
                Node<T> nowNode = first;
                newNode = FindNodeByIndex(index);
                Node<T> nextNode = nowNode.next;
                nowNode.next = newNode;
                newNode.previous = nowNode;
                newNode.next = nextNode;
                nextNode.previous = newNode;
                Count++;
            }
        }


        public void Remove(T Value)
        {
            if (Find(Value) == null)
            {
                throw new ListExeption("Нет элемента");
            }
            Node<T> now = Find(Value);
            if (now.Equals(first))
            {
                first = first.next;
                first.previous = null;
            }
            else if (now.Equals(last))
            {
                last = last.previous;
                last.next = null;
            }
            else
            {
                Remover(now);
            }
            Count--;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count - 1 || first == null)
            {
                throw new ListExeption("Неверный индекс");
            }
            if (index == 0)
            {
                if (first.next != null)
                {
                    first = first.next;
                    first.previous = null;
                }
                else
                {
                    first = null;
                    last = null;
                }
            }
            else if (index == Count)
            {
                last = last.previous;
                last.next = null;
            }
            else
            {
                Remover(FindNodeByIndex(index));
            }
            Count--;
        }
        public ref T FindRef(T value)
        {
            if (Find(value) == null)
            {
                throw new ListExeption("Нет элемента");
            }
            return ref Find(value).value;
            
        }
        public T FindId(int index)
        {
            if (FindNodeByIndex(index) == null)
            {
                throw new ListExeption("Неверный индекс");
            }
            return FindNodeByIndex(index).value;
        }
        T[] ToArray()
        {
            if (first == null)
            {
                return new T[0];
            }
            if (last == first)
            {
                return new T[1] { last.value };
            }
            T[] result = new T[Count];
            Node<T> now = first;
            for (int i = 0; now != null; i++)
            {
                result[i] = now.value;
                now = now.next;
            }
            return result;
        }
        public void Sort()
        {
            Node<T> now;
            bool run = true;
            while (run)
            {
                now = first;
                run = false;
                while (now.next != null)
                {
                    if (SortRule.Invoke(now))
                    {
                        Swap(now, now.next);
                        run = true;
                        break;
                    }
                    else
                    {
                        now = now.next;
                    }
                }
            }
        }
        void Swap(Node<T> node1, Node<T> node2)
        {
            Node<T> nodebefore = node1.previous;
            Node<T> nodeafter = node2.next;
            if (nodebefore != null)
                nodebefore.next = node2;
            else
                first = node2;
            node2.previous = nodebefore;
            node2.next = node1;
            node1.previous = node2;
            node1.next = nodeafter;
            if (nodeafter != null)
                nodeafter.previous = node1;
            else
                last = node1;
        }
        void Remover(Node<T> now)
        {
            Node<T> prevNode = now.previous;
            Node<T> nextNode = now.next;
            if (prevNode != null)
                prevNode.next = nextNode;
            if (nextNode != null)
                nextNode.previous = prevNode;
        }
        Node<T> FindNodeByIndex(int index)
        {
            if (first == null)
                return null;
            Node<T> now = first;
            while (index != 0 && Count != 1)
            {
                if(now == null)
                {
                    return null;
                }
                now = now.next;
                index--;
            }
            return now;
        }
        Node<T> Find(T value)
        {
            if (first == null)
                return null;
            Node<T> now = first;
            while (!now.value.Equals(value))
            {
                now = now.next;
            }
            return now;
        }
        /// Функции доп. задание
        public NewList<T> Split(out NewList<T> outList)
        {
            NewList<T> newList = new NewList<T>();
            outList = new NewList<T>();
            Node<T> middle = FindNodeByIndex(Count / 2);
            outList.last = middle.previous;
            outList.first = first;
            newList.first = middle;
            newList.last = last;
            outList.last.next = null;
            middle.previous = null;
            return newList;
        }
        public NewList<T> Merge(in NewList<T> listToMerge)
        {
            last.next = listToMerge.first;
            listToMerge.first.previous = last.next;
            last = listToMerge.last;
            return this;
        }
        public NewList<T> SortedMerge(NewList<T> SortedList)
        {
            NewList<T> result = new NewList<T> { };
            NewList<T> nodesToAdd = new NewList<T> { };
            nodesToAdd.Append(first.value);
            nodesToAdd.Append(SortedList.first.value);
            this.RemoveAt(0);
            SortedList.RemoveAt(0);
            nodesToAdd.SortRule = SortedList.SortRule;
            while (true)
            {
                if (nodesToAdd.SortRule.Invoke(nodesToAdd.first))
                {
                    result.Append(nodesToAdd[0]);
                    if (this.Count > 0)
                    {
                        nodesToAdd[0] = this[0];
                        this.RemoveAt(0);
                    }
                    else
                    {
                        nodesToAdd.RemoveAt(0);
                        break;
                    }
                }
                else
                {
                    result.Append(nodesToAdd[1]);
                    if (SortedList.Count > 0)
                    {
                        nodesToAdd[1] = SortedList[0];
                        SortedList.RemoveAt(0);
                    }
                    else
                    {
                        nodesToAdd.RemoveAt(1);
                        break;
                    }
                }
            }
            result.Append(nodesToAdd[0]);
            foreach(T t in this)
            {
                result.Append(t);
            }
            foreach (T t in SortedList)
            {
                result.Append(t);
            }
            result.SortRule = SortedList.SortRule;
            return result;
        }
        public NewList<T> FastSort()
        {
            NewList<T> result = new NewList<T> { };
            NewList<NewList<T>> Lists;
            FastSort(out Lists, this);
            foreach(NewList<T> ls in Lists)
            {
                foreach(T t in ls)
                {
                    result.Append(t);
                }
            }
            return result;
        }
        private void FastSort(out NewList<NewList<T>> lists, NewList<T> listToSort)
        {
            int startSize = listToSort.Count;
            lists = new NewList<NewList<T>> {};
            lists.Append(listToSort);
            while(startSize != lists.Count)
            {
                int n = lists.Count;
                for (int i = 0; i != n; i++)
                {
                    NewList<T> secondList;
                    if (lists[i].Count > 1)
                    {
                        lists[i] = lists[i].Split(out secondList);
                        lists.Append(secondList);                       
                    }
                }
            }
            foreach (NewList<T> nl in lists)
            {
                nl.SortRule = listToSort.SortRule;
            }
            while (lists.Count != 1)
            {

                lists[0] = lists[0].SortedMerge(lists[1]);
                lists.RemoveAt(1);
            }           
        }
    }
}
