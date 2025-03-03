using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListImplementation.LinkedListModel
{
    internal class SinglyLinkedList<T> : ILinkedList<T?>
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

        int ICollection<T?>.Count => throw new NotImplementedException();

        public void Add(T? item)
        {
            AddToEnd(item);
        }

        public void AddToEnd(T? item)
        {
            Node<T> nodeToEnd = new(item);
            if(_head is null)
            {
                _head = nodeToEnd;
            }
            else
            {
                Node<T> tail = GetNodes().Last();
                tail.Next = nodeToEnd;
            }
            _count++;
        }

        public void AddToFront(T? item)
        {
            Node<T> nodeToFront = new(item);
            nodeToFront.Next = _head;
            // Setting it as new head.
            _head = nodeToFront;
            _count++;
        }

        public void Clear()
        {
            Node<T>? current = _head;
            while (current is not null)
            {
                Node<T>? temporary = current;
                current = current.Next;
                temporary.Next = null;   
            }
        }

        public bool Contains(T? item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T?[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T?> GetEnumerator()
        {
            foreach(var node in GetNodes())
            {
                yield return node.Value;
            }
        }

        public bool Remove(T? item)
        {
            Node<T>? predecessor = null;
            foreach (var currentNode in GetNodes())
            {
                if ((currentNode.Value is null && item is null) || ((currentNode.Value is not null) && currentNode.Value.Equals(item)))
                {
                    if(predecessor is null)
                    {
                        _head = currentNode.Next;
                    }
                    else {
                       predecessor.Next = currentNode.Next;
                    }

                    --_count;
                    return true;
                }
                predecessor = currentNode;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<Node<T>> GetNodes()
        {
            // No itaration if head is null.
            if(_head is null)
            {
                yield break;
            }

            Node<T>? current = _head;
            while(current is not null)
            {
                yield return current;
                current = current.Next;
            }
        }
    }
}
