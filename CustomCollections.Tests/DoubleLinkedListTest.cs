using CustomCollections.ArrayLists;

namespace CustomCollections.Tests;

[TestClass]
public class DoubleLinkedListTest
{
    static DoubleLinkedList<int>.Node node = new(1);
    static DoubleLinkedList<int>.Node node2 = new(2);
    static DoubleLinkedList<int>.Node node3 = new(3);

    static private void UpdateNodes()
    {
        node = new(1);
        node2 = new(2);
        node3 = new(3);
    }

    [TestClass]
    public class AddNode
    {

        [TestClass]
        public class AddAfterNode
        {
            [TestMethod]
            public void ToEmptyList()
            {
                var expected = 5;
                var list = new DoubleLinkedList<int>();
                var newNode = new DoubleLinkedList<int>.Node(5);

                list.InsertAfter(null, newNode);

                var actual = list[0].Value;

                Assert.AreEqual(expected, actual, "");
                UpdateNodes();
            }

            [TestMethod]
            public void ToExistedList()
            {
                var expectedFirst = 1;
                var expected1 = 5;
                var expected2 = 2;

                var list = new DoubleLinkedList<int>(node);
                list.InsertAfter(node, node2);
                list.InsertAfter(node2, node3);

                var newNode = new DoubleLinkedList<int>.Node(5);

                list.InsertAfter(node, newNode);

                var actual_first = list[0].Value;
                var actual1 = list[1].Value;
                var actual2 = list[2].Value;

                Assert.AreEqual(expectedFirst, actual_first, "");
                Assert.AreEqual(expected1, actual1, "");
                Assert.AreEqual(expected2, actual2, "");
                UpdateNodes();
            }
        }

        [TestClass]
        public class AddLastNode
        {
            [TestMethod]
            public void ToEmptyList()
            {
                var expected = 1;
                var list = new DoubleLinkedList<int>();

                list.InsertLast(node);

                var actual = list[0].Value;

                Assert.AreEqual(expected, actual, "");
                UpdateNodes();
            }

            [TestMethod]
            public void ToExistedList()
            {
                var expected = 1;
                var expected2 = 2;
                var expected3 = 3;
                var list = new DoubleLinkedList<int>(node);
                list.InsertLast(node2);
                list.InsertLast(node3);

                var actual = list[0].Value;
                var actual2 = list[1].Value;
                var actual3 = list[2].Value;

                Assert.AreEqual(expected, actual, "");
                Assert.AreEqual(expected2, actual2, "");
                Assert.AreEqual(expected3, actual3, "");
                UpdateNodes();
            }
        }

        [TestClass]
        public class AddFirstNode
        {
            [TestMethod]
            public void ToEmptyList()
            {
                var expected = 1;
                var list = new DoubleLinkedList<int>();

                list.InsertFirst(node);

                var actual = list[0].Value;

                Assert.AreEqual(expected, actual, "");
                UpdateNodes();
            }

            [TestMethod]
            public void ToExistedList()
            {
                var expected = 5;
                var newNode = new DoubleLinkedList<int>.Node(expected);
                var list = new DoubleLinkedList<int>(node);

                list.InsertFirst(newNode);

                var actual = list[0].Value;

                Assert.AreEqual(expected, actual, "");
                UpdateNodes();
            }
        }
    }

    [TestClass]
    public class Remove
    {
        [TestMethod]
        public void RemoveNode()
        {
            var list = new DoubleLinkedList<int>(new[] { node, node2, node3 });

            var expected = node;

            list.RemoveNode(node);

            var actual = list[0];

            Assert.AreNotEqual(expected, actual, "");
            UpdateNodes();
        }

        [TestMethod]
        public void RemoveLastNode()
        {
            var list = new DoubleLinkedList<int>(node);
            var expected = 0;

            list.RemoveNode(node);

            var actual = list.Count();

            Assert.AreEqual(expected, actual, "");
            UpdateNodes();
        }
    }

    [TestClass]
    public class Find
    {
        [TestMethod]
        public void Find_FirstNode()
        {
            var list = new DoubleLinkedList<int>(new[] { node, node2, node3 });

            var expected = node;
            var actual = list.Find(1);

            Assert.AreEqual(expected, actual, "");
            UpdateNodes();
        }

        [TestMethod]
        public void Find_Node()
        {
            var list = new DoubleLinkedList<int>(new[] { node, node2, node3 });

            var expected = node2;
            var actual = list.Find(2);

            Assert.AreEqual(expected, actual, "");
            UpdateNodes();
        }


        [TestMethod]
        public void DoNot_Find_Node_AfterRemoving()
        {
            var list = new DoubleLinkedList<int>(new[] { node, node2, node3 });

            var expected = node;

            list.RemoveNode(node);

            var actual = list.Find(1);

            Assert.AreNotEqual(expected, actual, "");
            UpdateNodes();
        }
    }
}