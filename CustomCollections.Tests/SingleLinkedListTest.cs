using CustomCollections.ArrayLists;

namespace CustomCollections.Tests;

[TestClass]
public class SingleLinkedListTest
{
    [TestClass]
    public class AddNode
    {
        [TestMethod]
        public void AddFirstNode_ToEmptyList()
        {
            var expected = 1;
            var node = new SingleLinkedList<int>.Node(expected);
            var list = new SingleLinkedList<int>();

            list.InsertFirst(node);

            var actual = list[0].Value;

            Assert.AreEqual(expected, actual, "");
        }

        [TestMethod]
        public void AddFirstNode_ToExistedList()
        {
            var expected = 5;
            var node = new SingleLinkedList<int>.Node(1);
            var newNode = new SingleLinkedList<int>.Node(expected);
            var list = new SingleLinkedList<int>(node);

            list.InsertFirst(newNode);

            var actual = list[0].Value;

            Assert.AreEqual(expected, actual, "");
        }

        [TestMethod]
        public void AddFirstNode_Null()
        {
            var node = new SingleLinkedList<int>.Node(1);
            var list = new SingleLinkedList<int>(node);

            list.InsertFirst(null);

            var actual = list[0];

            Assert.AreEqual(expected: null, actual, "");
        }

        [TestMethod]
        public void AddAfterNode_ToEmptyList()
        {
            var expected = 5;
            var list = new SingleLinkedList<int>();
            var newNode = new SingleLinkedList<int>.Node(5);

            list.InsertAfter(null, newNode);

            var actual = list[0].Value;

            Assert.AreEqual(expected, actual, "");
        }

        [TestMethod]
        public void AddAfterNode_ToExistedList()
        {
            var expectedFirst = 1;
            var expected1 = 5;
            var expected2 = 2;
            var expected3 = 3;
            var node = new SingleLinkedList<int>.Node(1);
            var node2 = new SingleLinkedList<int>.Node(2);
            var node3 = new SingleLinkedList<int>.Node(3);
            var list = new SingleLinkedList<int>();
            list.InsertLast(node);
            list.InsertLast(node2);
            list.InsertLast(node3);
            var newNode = new SingleLinkedList<int>.Node(5);

            list.InsertAfter(node, newNode);

            var actual_first = list[0].Value;
            var actual1 = list[1].Value;
            var actual2 = list[2].Value;
            var actual3 = list[3].Value;

            Assert.AreEqual(expectedFirst, actual_first, "");
            Assert.AreEqual(expected1, actual1, "");
            Assert.AreEqual(expected2, actual2, "");
            Assert.AreEqual(expected3, actual3, "");
        }

        [TestMethod]
        public void AddLastNode_ToEmptyList()
        {
            var expected = 1;
            var node = new SingleLinkedList<int>.Node(expected);
            var list = new SingleLinkedList<int>();

            list.InsertLast(node);

            var actual = list[0].Value;

            Assert.AreEqual(expected, actual, "");
        }

        [TestMethod]
        public void AddLastNode_ToExistedList()
        {
            var expected = 5;
            var node = new SingleLinkedList<int>.Node(1);
            var node2 = new SingleLinkedList<int>.Node(2);
            var node3 = new SingleLinkedList<int>.Node(3);
            var list = new SingleLinkedList<int>();
            list.InsertFirst(node);
            list.InsertFirst(node2);
            list.InsertFirst(node3);
            var newNode = new SingleLinkedList<int>.Node(expected);

            list.InsertLast(newNode);

            var actual = list[3].Value;

            Assert.AreEqual(expected, actual, "");
        }
    }

    [TestClass]
    public class Remove
    {
        [TestMethod]
        public void RemoveNode()
        {
            var node = new SingleLinkedList<int>.Node(1);
            var node2 = new SingleLinkedList<int>.Node(2);
            var node3 = new SingleLinkedList<int>.Node(3);
            var list = new SingleLinkedList<int>();
            list.InsertFirst(node);
            list.InsertFirst(node2);
            list.InsertFirst(node3);

            var expected = node;

            list.RemoveNode(node);

            var actual = list[0];

            Assert.AreNotEqual(expected, actual, "");
        }

        [TestMethod]
        public void RemoveLastNode()
        {
            var node = new SingleLinkedList<int>.Node(1);
            var list = new SingleLinkedList<int>(node);
            var expected = 0;

            list.RemoveNode(node);

            var actual = list.Count();

            Assert.AreEqual(expected, actual, "");
        }
    }

    [TestClass]
    public class Find
    {
        [TestMethod]
        public void Find_FirstNode()
        {
            var node = new SingleLinkedList<int>.Node(1);
            var node2 = new SingleLinkedList<int>.Node(2);
            var node3 = new SingleLinkedList<int>.Node(3);
            var list = new SingleLinkedList<int>();
            list.InsertLast(node);
            list.InsertLast(node2);
            list.InsertLast(node3);

            var expected = node;
            var actual = list.Find(1);

            Assert.AreEqual(expected, actual, "");
        }

        [TestMethod]
        public void Find_Node()
        {
            var node = new SingleLinkedList<int>.Node(1);
            var node2 = new SingleLinkedList<int>.Node(2);
            var node3 = new SingleLinkedList<int>.Node(3);
            var list = new SingleLinkedList<int>();
            list.InsertLast(node);
            list.InsertLast(node2);
            list.InsertLast(node3);

            var expected = node2;
            var actual = list.Find(2);

            Assert.AreEqual(expected, actual, "");
        }


        [TestMethod]
        public void DoNot_Find_Node_AfterRemoving()
        {
            var node = new SingleLinkedList<int>.Node(1);
            var node2 = new SingleLinkedList<int>.Node(2);
            var node3 = new SingleLinkedList<int>.Node(3);
            var list = new SingleLinkedList<int>();
            list.InsertLast(node);
            list.InsertLast(node2);
            list.InsertLast(node3);

            var expected = node;

            list.RemoveNode(node);

            var actual = list.Find(1);

            Assert.AreNotEqual(expected, actual, "");
        }
    }
}