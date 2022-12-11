using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Text;

namespace CustomCollections.ArrayList
{
    public class ArrayListT
    {
        private object[] contents;
        private int size;

        public ArrayListT()
        {
            contents = new object[size];
        }

        public ArrayListT(int size)
        {
            this.size = size;
            contents = new object[size];
        }

        public ArrayListT(ArrayListT arrayList)
        {
            contents = new object[size];
            AddRange(arrayList);
        }

        public ArrayListT(ICollection collection)
        {
            contents = new object[size];
            AddRange(collection);
        }

        public object this[int index]
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

        public int Count
        {
            get
            {
                return size;
            }
        }

        public int Add(object value)
        {
            var index = contents.Length;
            if (size == contents.Length)
                EncreaseArray(encreasingValue: 1);

            contents[index] = value;
            return index;
        }

        public void AddRange([NotNull] ArrayListT arrayList)
        {
            var count = arrayList.Count;
            var index = size;
            if (count > 0)
            {
                EncreaseArray(size + count);

                var itemsToInsert = new object[count];
                arrayList.CopyTo(itemsToInsert, 0);
                itemsToInsert.CopyTo(contents, index);
            }
        }

        private void AddRange(ICollection collection)
        {
            var count = collection.Count;
            var index = size;
            if (count > 0)
            {
                EncreaseArray(size + count);

                var itemsToInsert = new object[count];
                collection.CopyTo(itemsToInsert, 0);
                itemsToInsert.CopyTo(contents, index);
            }
        }

        public void Remove(object item) =>
            RemoveAt(IndexOf(item));

        public int IndexOf(object item)
            => Array.IndexOf((Array)contents, item, 0, size);

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

        private void CopyTo(object[] itemsToInsert, int index) =>
            Array.Copy(contents, 0, itemsToInsert, index, size);

        private void EncreaseArray(int encreasingValue)
        {
            int newArraySize = contents.Length == 0 ? encreasingValue : contents.Length + encreasingValue;

            object[] newContents = new object[newArraySize];
            if (size > 0)
            {
                Array.Copy(contents, 0, newContents, 0, size);
            }
            contents = newContents;
            size = newArraySize;
        }

        public void Clear()
        {
            if (size > 0)
            {
                Array.Clear(contents, 0, size);
                size = 0;
            }
        }

    }
}
