using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace CustomCollections.ArrayLists
{
    // - T this[int index]
    // - void Insert(int index, T item);
    // - void RemoveAt(int index);
    // - void Add(T item);
    // - void Clear()
    public class ArrayListGeneric<T> : IList
    {
        private T[] contents;
        private int size;

        public ArrayListGeneric()
        {
            contents = new T[size];
        }

        public ArrayListGeneric(int size)
        {
            this.size = size;
            contents = new T[size];
        }

        public ArrayListGeneric(ICollection collection)
        {
            contents = new T[size];
            AddRange(collection);
        }

        public T this[int index]
        {
            get
            {
                return contents[index];
            }
            set
            {
                contents[index] = value;
            }
        }

        private void AddRange(ICollection collection)
        {
            var count = collection.Count;
            var index = size;

            if (count > 0)
            {
                EncreaseArray(size + count);

                var itemsToInsert = new T[count];
                collection.CopyTo(itemsToInsert, 0);
                itemsToInsert.CopyTo(contents, index);
            }
        }

        public int Count
        {
            get
            {
                return size;
            }
        }

        public int Add(T value)
        {
            var index = contents.Length;
            if (size == contents.Length)
                EncreaseArray(encreasingValue: 1);
            contents[index] = value;
            return index;
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                for (int i = index; i < Count - 1; i++)
                {
                    contents[i] = contents[i + 1];
                }
                size--;
            }
        }

        public virtual void Clear()
        {
            if (size == 0)
                return;

            int i = size;
            size = 0;

            while (i > size)
                contents[--i] = default;
        }

        public virtual void Insert(int index, T value)
        {
            if (size == contents.Length)
                EncreaseArray(encreasingValue: 1);

            var temp = new T[size];
            for (int i = 0, j = 0; i < size; i++, j++)
            {
                if (i == index)
                {
                    temp[index] = value;
                    i++;
                    continue;
                }

                temp[i] = contents[j];
            }

            Array.Copy(temp, 0, contents, 0, size);
        }

        private void EncreaseArray(int encreasingValue)
        {
            int newArraySize = contents.Length == 0 ? encreasingValue : contents.Length + encreasingValue;

            T[] newContents = new T[newArraySize];
            if (size > 0)
            {
                Array.Copy(contents, 0, newContents, 0, size);
            }
            contents = newContents;
            size = newArraySize;
        }

        public bool Contains(T value)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            Array.Copy(contents, 0, array, index, size);
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public bool IsFixedSize => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public T SyncRoot => throw new NotImplementedException();

        object ICollection.SyncRoot => throw new NotImplementedException();

        object IList.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
