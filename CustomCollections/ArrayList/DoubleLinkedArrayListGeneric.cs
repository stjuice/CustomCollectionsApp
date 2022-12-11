using System;
using System.Collections.Generic;

namespace CustomCollections.ArrayList
{
    public class DoubleLinkedArrayListGeneric<T>
    {
        public class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; set; }

            public Node Next { get; set; }
            public Node Prev { get; set; }
        }

        private Node head;
        private Node tail;

        public T this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void GetFirstNode()
        {
            throw new NotImplementedException();
        }

        public void AddItem(T item)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(T item)
        {
            throw new NotImplementedException();
        }

        public void AddLast(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveNode(T item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Node> Iterate()
        {
            var currentNode = head;

            while (currentNode != null)
            {
                yield return currentNode;

                currentNode = currentNode.Next;
            }
        }

        private void InsertLast(Node newNode)
        {
            throw new NotImplementedException();
        }

        private void InsertAfter(Node existingNode, Node newNode)
        {
            throw new NotImplementedException();
        }

        private void InsertNode(Node newNode)
        {
            throw new NotImplementedException();
        }

        private Node Find(T searchedValue)
        {
            throw new NotImplementedException();
        }
    }
}
