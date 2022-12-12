using CustomCollections.ArrayLists;

namespace CustomCollections.Tests;

[TestClass]
public class SingleLinkedListTest
{
    static SingleLinkedList<int>.Node node = new(1);
    static SingleLinkedList<int>.Node node2 = new(2);
    static SingleLinkedList<int>.Node node3 = new(3);

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
        public class AddLastNode
        {
            [TestMethod]
            public void ToEmptyList()
            {
                var expected = 1;
                var list = new SingleLinkedList<int>();

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
                var list = new SingleLinkedList<int>(node);
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
                var list = new SingleLinkedList<int>();

                list.InsertFirst(node);

                var actual = list[0].Value;

                Assert.AreEqual(expected, actual, "");
                UpdateNodes();
            }

            [TestMethod]
            public void ToExistedList()
            {
                var expected = 5;
                var newNode = new SingleLinkedList<int>.Node(expected);
                var list = new SingleLinkedList<int>(node);

                list.InsertFirst(newNode);

                var actual = list[0].Value;

                Assert.AreEqual(expected, actual, "");
                UpdateNodes();
            }

            [TestMethod]
            public void AsNull()
            {
                var list = new SingleLinkedList<int>(node);

                list.InsertFirst(null);

                var actual = list[0];

                Assert.AreEqual(expected: null, actual, "");
                UpdateNodes();
            }
        }

        [TestClass]
        public class AddAfterNode
        {
            [TestMethod]
            public void ToEmptyList()
            {
                var expected = 5;
                var list = new SingleLinkedList<int>();
                var newNode = new SingleLinkedList<int>.Node(5);

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
                var expected3 = 3;
                var existedList = new SingleLinkedList<int>(new[] { node, node2, node3 });

                var newNode = new SingleLinkedList<int>.Node(5);

                existedList.InsertAfter(node, newNode);

                var actual_first = existedList[0].Value;
                var actual1 = existedList[1].Value;
                var actual2 = existedList[2].Value;
                var actual3 = existedList[3].Value;

                Assert.AreEqual(expectedFirst, actual_first, "");
                Assert.AreEqual(expected1, actual1, "");
                Assert.AreEqual(expected2, actual2, "");
                Assert.AreEqual(expected3, actual3, "");
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
            var list = new SingleLinkedList<int>(new[] { node, node2, node3 });

            var expected = node;

            list.RemoveNode(node);

            var actual = list[0];

            Assert.AreNotEqual(expected, actual, "");
            UpdateNodes();
        }

        [TestMethod]
        public void RemoveLastNode()
        {
            var list = new SingleLinkedList<int>(node);
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
            var list = new SingleLinkedList<int>(new[] { node, node2, node3 });

            var expected = node;
            var actual = list.Find(1);

            Assert.AreEqual(expected, actual, "");
            UpdateNodes();
        }

        [TestMethod]
        public void Find_Node()
        {
            var list = new SingleLinkedList<int>(new[] { node, node2, node3 });

            var expected = node2;
            var actual = list.Find(2);

            Assert.AreEqual(expected, actual, "");
            UpdateNodes();
        }


        [TestMethod]
        public void DoNot_Find_Node_AfterRemoving()
        {
            var list = new SingleLinkedList<int>(new[] { node, node2, node3 });

            var expected = node;

            list.RemoveNode(node);

            var actual = list.Find(1);

            Assert.AreNotEqual(expected, actual, "");
            UpdateNodes();
        }
    }
}