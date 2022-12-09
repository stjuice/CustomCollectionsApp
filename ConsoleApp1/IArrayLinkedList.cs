using System;
using System.Collections.Generic;
using System.Text;

namespace CustomCollections
{
    internal interface IArrayLinkedList<T, Node>
    {
        public void GetFirstNode();

        public void AddItem(T item);

        public void AddFirst(T item);

        public void AddLast(T item);

        public void RemoveNode(T item);

        public bool Contains(T value);

        public IEnumerable<Node> Iterate();

        abstract void InsertLast(Node newNode);

        abstract void InsertAfter(Node existingNode, Node newNode);

        abstract void InsertNode(Node newNode);

        abstract Node Find(T searchedValue);
    }
}
