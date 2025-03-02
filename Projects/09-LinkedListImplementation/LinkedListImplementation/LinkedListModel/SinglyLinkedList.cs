using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListImplementation.LinkedListModel
{
    internal class SinglyLinkedList<T> : ILinkedList<T>
    {
        private Node<T>? _head;
        private int _count;

        public SinglyLinkedList()
        {
            _head = null;
        }
        public SinglyLinkedList(Node<T> head)
        {
            _head = head;
            head.Next = null;
        }

        public int Count() => _count;

        // Linkedlist is not read-only.
        public bool IsReadOnly => false;

        public void Add(T? item)
        {
            throw new NotImplementedException();
        }

        public void AddToEnd(T? item)
        {
            throw new NotImplementedException();
        }

        public void AddToFront(T? item)
        {
            Node<T> nodeToAdd = new(item);
            nodeToAdd.Next = _head;
            // Setting it as new head.
            _head = nodeToAdd;
            _count++;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T? item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T?[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T? item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
