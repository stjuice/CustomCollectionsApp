using System.Collections.Generic;

namespace CustomCollectionsApp
{
    public class SingleLinkedArrayListGeneric<T>
    {
        public class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; set; }

            public Node Next { get; set; }
        }

        private Node head;
        private Node tail;

        public T this[int index]
        {
            get
            {
                var currentNode = head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                return currentNode.Value;
            }
            set
            {
                var currentNode = head;
                for (int i = 1; i <= index; i++)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Value = value;
            }
        }

        public void GetFirstNode()
        {
            Node current = head;
            if (current != null)
                while (current != null)
                    current = current.Next;
        }

        public void AddItem(T item)
        {
            var newNode = new Node(item);
            InsertAfter(tail, newNode);
        }

        public void AddFirst(T item)
        {
            var newNode = new Node(item);
            if (head is null)
                head = tail = newNode;
            else
                head = newNode;
        }

        public void RemoveNode(T item)
        {
            Node current = head;
            if (current == null)
                return;

            if (current.Value.Equals(item))
            {
                if (current.Next != null)
                    current = current.Next;
                else
                    current = null;

                head = current;
            }
            else
            {
                while (current.Next != null && !current.Next.Value.Equals(item))
                {
                    current = current.Next;
                }

                if (current.Next != null && current.Next.Value.Equals(item))
                    current.Next = current.Next.Next;
            }
        }

        public bool Contains(T value)
        {
            return Find(value) != null;
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

        public void AddLast(T item)
        {
            var newNode = new Node(item);
            InsertLast(newNode);
        }

        private void InsertLast(Node newNode)
        {
            if (tail is null)
            {
                head = tail = newNode;
            }
            else
            {
                InsertAfter(tail, newNode);
            }
        }

        private void InsertAfter(Node existingNode, Node newNode)
        {
            if (existingNode is null)
                head = newNode;
            else
                existingNode.Next = newNode;

            tail = newNode;
        }

        private void InsertNode(Node newNode)
        {
            if (head != null)
            {
                head.Next = newNode;
            }
            else
            {
                head = newNode;
            }
        }

        private Node Find(T searchedValue)
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
    }
} 