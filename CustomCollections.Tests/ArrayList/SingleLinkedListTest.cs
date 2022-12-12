using CustomCollections.ArrayLists;
using System.Collections;

namespace CustomCollections.Tests;

[TestClass]
public class SingleLinkedListTest_With_ArrayListGeneric
{
    [TestMethod]
    public void AddLast()
    {
        var arrayList = new ArrayListGeneric<string>(new[] { "blue", "black", "violet" });
        var arrayList2 = new ArrayListGeneric<string>(new[] { "first", "second" });
        var arrayList3 = new ArrayListGeneric<string>(new[] { "bowl", "pan", "chopstick" });
        var node = new SingleLinkedList<ArrayListGeneric<string>>.Node(arrayList);
        var node2 = new SingleLinkedList<ArrayListGeneric<string>>.Node(arrayList2);
        var node3 = new SingleLinkedList<ArrayListGeneric<string>>.Node(arrayList3);

        var expected = arrayList;
        var expected2 = arrayList2;
        var expected3 = arrayList3;
        var list = new SingleLinkedList<ArrayListGeneric<string>>(node);
        list.InsertLast(node2);
        list.InsertLast(node3);

        var actual = list[0].Value;
        var actual2 = list[1].Value;
        var actual3 = list[2].Value;

        Assert.AreEqual(expected, actual, "");
        Assert.AreEqual(expected2, actual2, "");
        Assert.AreEqual(expected3, actual3, "");
    }
    [TestMethod]

    public void AddFirst()
    {
        var arrayList = new ArrayListGeneric<string>(new[] { "blue", "black", "violet" });
        var arrayList2 = new ArrayListGeneric<string>(new[] { "first", "second" });
        var arrayList3 = new ArrayListGeneric<string>(new[] { "bowl", "pan", "chopstick" });
        var expected_arrayList = new ArrayListGeneric<string>(new[] { "13", "43", "57", "09" });

        var node = new SingleLinkedList<ArrayListGeneric<string>>.Node(arrayList);
        var node2 = new SingleLinkedList<ArrayListGeneric<string>>.Node(arrayList2);
        var node3 = new SingleLinkedList<ArrayListGeneric<string>>.Node(arrayList3);
        var expected_node = new SingleLinkedList<ArrayListGeneric<string>>.Node(expected_arrayList);

        var expected = expected_node.Value;
        var list = new SingleLinkedList<ArrayListGeneric<string>>(new []{node, node2, node3});

        list.InsertFirst(expected_node);

        var actual = list[0].Value;

        Assert.AreSame(expected, actual, "");
    }

    [TestMethod]
    public void AddAfter()
    {
        var arrayList = new ArrayListGeneric<string>(new[] { "blue", "black", "violet" });
        var arrayList2 = new ArrayListGeneric<string>(new[] { "first", "second" });
        var arrayList3 = new ArrayListGeneric<string>(new[] { "13", "43", "57", "09" });

        var newArrayList = new ArrayListGeneric<string>(new[] { "bowl", "pan", "chopstick" });

        var node = new SingleLinkedList<ArrayListGeneric<string>>.Node(arrayList);
        var node2 = new SingleLinkedList<ArrayListGeneric<string>>.Node(arrayList2);
        var node3 = new SingleLinkedList<ArrayListGeneric<string>>.Node(arrayList3);

        var list = new SingleLinkedList<ArrayListGeneric<string>>(new[] { node, node2, node3 });

        var newNode = new SingleLinkedList<ArrayListGeneric<string>>.Node(newArrayList);

        list.InsertAfter(node, newNode);

        var expected1 = arrayList;
        var expected = newArrayList;
        var expected2 = arrayList2;
        var expected3 = arrayList3;

        var actual1 = list[0].Value;
        var actual = list[1].Value;
        var actual2 = list[2].Value;
        var actual3 = list[3].Value;

        Assert.AreEqual(expected, actual, "");
        Assert.AreEqual(expected1, actual1, "");
        Assert.AreEqual(expected2, actual2, "");
        Assert.AreEqual(expected3, actual3, "");
    }

    [TestMethod]
    public void RemoveNode()
    {
        var arrayList = new ArrayListGeneric<string>(new[] { "blue", "black", "violet" });
        var arrayList2 = new ArrayListGeneric<string>(new[] { "first", "second" });
        var arrayList3 = new ArrayListGeneric<string>(new[] { "13", "43", "57", "09" });

        var node = new SingleLinkedList<ArrayListGeneric<string>>.Node(arrayList);
        var node2 = new SingleLinkedList<ArrayListGeneric<string>>.Node(arrayList2);
        var node3 = new SingleLinkedList<ArrayListGeneric<string>>.Node(arrayList3);

        var list = new SingleLinkedList<ArrayListGeneric<string>>(new[] { node, node2, node3 });

        var expected = node;

        list.RemoveNode(node);

        var actual = list.Find(arrayList);

        Assert.AreNotEqual(expected, actual, "");
    }


    [TestMethod]
    public void Find_Node()
    {
        var arrayList = new ArrayListGeneric<string>(new[] { "blue", "black", "violet" });
        var arrayList2 = new ArrayListGeneric<string>(new[] { "first", "second" });
        var arrayList3 = new ArrayListGeneric<string>(new[] { "13", "43", "57", "09" });

        var node = new SingleLinkedList<ArrayListGeneric<string>>.Node(arrayList);
        var node2 = new SingleLinkedList<ArrayListGeneric<string>>.Node(arrayList2);
        var node3 = new SingleLinkedList<ArrayListGeneric<string>>.Node(arrayList3);

        var list = new SingleLinkedList<ArrayListGeneric<string>>(new[] { node, node2, node3 });

        var expected = node2;
        var actual = list.Find(arrayList2);

        Assert.AreEqual(expected, actual, "");
    }
}