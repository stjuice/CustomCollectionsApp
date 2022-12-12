using System.Collections.Generic;

namespace CustomCollections.ArrayLists
{
    public class SingleLinkedList<T>
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

        private Node head = null;
        private Node tail = null;

        public SingleLinkedList()
        {
        }

        public SingleLinkedList(Node node)
        {
            head = node;
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

        public void InsertFirst(Node newNode)
        {
            if (newNode is null)
                head = newNode;

            var oldHead = head;
            if (head is null)
                head = tail = newNode;
            else
                head = newNode;

            if (head != null)
                head.Next = oldHead;
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
            Node current = head;
            if (current == null)
                return;

            if (current.Equals(node))
            {
                if (current.Next != null)
                    current = current.Next;
                else
                    current = null;

                head = current;
            }
            else
            {
                while (current.Next != null && !current.Equals(node))
                {
                    current = current.Next;
                }

                if (current.Next != null && current.Equals(node))
                    current.Next = current.Next.Next;
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
            else if (existingNode != null)
            {
                var nextNode = existingNode.Next;

                if (nextNode != null)
                {
                    newNode.Next = nextNode;
                }

                existingNode.Next = newNode;
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