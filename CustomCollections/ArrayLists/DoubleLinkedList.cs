using System;
using System.Collections.Generic;
using System.Threading;

namespace CustomCollections.ArrayLists
{
    public class DoubleLinkedList<T>
    {
        public class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; set; }

            public Node Previous { get; set; }

            public Node Next { get; set; }
        }

        private Node head = null;
        private Node tail = null;

        public DoubleLinkedList()
        {
        }

        public DoubleLinkedList(Node node)
        {
            head = tail = node;
        }

        public DoubleLinkedList(Node[] nodes)
        {
            foreach (var n in nodes)
            {
                InsertLast(n);
            }
        }

        public Node this[int index]
        {
            get
            {
                var currentNode = head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                return currentNode;
            }
        }

        public void InsertAfter(Node existingNode, Node newNode)
        {
            if (head is null)
            {
                head = tail = newNode;
            }
            else if (existingNode == tail)
            {
                existingNode.Next = tail = newNode;
            }
            else
            {
                var nextNode = existingNode.Next;

                if (nextNode != null)
                {
                    nextNode.Previous = newNode;
                    newNode.Next = nextNode;
                }

                existingNode.Next = newNode;
                newNode.Previous = existingNode;

                if (existingNode == tail)
                {
                    tail = newNode;
                }
            }
        }

        public void InsertBefore(Node existingNode, Node newNode)
        {
            var previousNode = existingNode.Previous;

            if (previousNode != null)
            {
                previousNode.Next = newNode;
                newNode.Previous = previousNode;
            }

            existingNode.Previous = newNode;
            newNode.Next = existingNode;

            if (existingNode == head)
            {
                head = newNode;
            }
        }

        public void InsertFirst(Node newNode)
        {
            if (head is null)
                head = tail = newNode;
            else
                InsertBefore(head, newNode);
        }

        public void InsertLast(Node newNode)
        {
            if (head is null)
            {
                head = tail = newNode;
            }
            else
            {
                InsertAfter(tail, newNode);
            }
        }

        public void RemoveNode(Node node)
        {
            var previousNode = node.Previous;
            var nextNode = node.Next;

            if (previousNode != null)
            {
                previousNode.Next = nextNode;
            }

            if (nextNode != null)
            {
                nextNode.Previous = previousNode;
            }

            if (head == node)
            {
                head = nextNode;
            }

            if (tail == node)
            {
                tail = previousNode;
            }
        }

        public Node Find(T searchedValue)
        {
            var currentNode = head;

            while (currentNode != null)
            {
                if (searchedValue.Equals(currentNode.Value))
                {
                    return currentNode;
                }

                currentNode = currentNode.Next;
            }

            return null;
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

        public int Count()
        {
            int count = 0;
            foreach (var item in Iterate())
            {
                count++;
            }

            return count;
        }
    }
}