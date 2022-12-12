using CustomCollections.ArrayLists;
using System;

namespace CustomCollectionsApp
{
    class Program
    {
        static void Main()
        {
            // 1. Implement ArrayList class.
            var arrayList = new ArrayListT();
            arrayList.Add(0);
            arrayList.Add(2);
            arrayList.Add(0);
            arrayList.Add(5);

            for (var i = 0; i <= arrayList.Count; i++) // check
                Console.WriteLine(arrayList[i]);

            arrayList.Add(7);

            for (var i = 0; i <= arrayList.Count; i++)
                Console.WriteLine(arrayList[i]);

            // 2. Make ArrayList generic: new ArrayList<string>();
            // 3. Implement interface IList:
            // - T this[int index]
            // - void Insert(int index, T item);
            // - void RemoveAt(int index);
            // - void Add(T item);
            // - void Clear()
            // - the rest can throw not implemented exception

            // 4. It is better to implement it via TDD. Write tests firsts, then write implementation.

            // 5. Implement the same as Singly-linked list.
            // 6. Implement the same as Doubly-linked list.

            //System.Collections.Generic.IList
        }
    }
}
