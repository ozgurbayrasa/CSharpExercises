using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListImplementation.LinkedListModel
{
    internal class LinkedList<T> : ILinkedList<T>
    {
        public Node<T> Head { get; }

        public LinkedList()
        {
            Head = null;
        }
        public LinkedList(Node<T> head)
        {
            Head = head;
            head.Next = null;
        }

        public int Count()
        {
            int count = 0;
            Node<T> currentNode = Head;


            while(currentNode.Next is not null)
            {
                currentNode = currentNode.Next;
                count++;
            }

            return count;
        }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void AddToEnd(T item)
        {
            throw new NotImplementedException();
        }

        public void AddToFront(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
