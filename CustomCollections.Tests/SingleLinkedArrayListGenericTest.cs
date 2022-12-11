using CustomCollectionsApp;
using System.Collections;

namespace CustomCollections.Tests
{
    [TestClass]
    public class SingleLinkedArrayListGenericTest
    {
        [TestClass]
        public class Add
        {
            [TestMethod]
            public void Add_Item()
            {
                // Arrange
                var list = new SingleLinkedArrayListGeneric<int>();
                var expected = 1;

                // Act
                list.AddItem(1);

                // Assert
                var actual = list[0];

                Assert.AreEqual(expected, actual, "");
            }

            [TestMethod]
            public void Add_Items()
            {
                // Arrange
                var list = new SingleLinkedArrayListGeneric<int>();
                var expectedItem1 = 1;
                var expectedItem2 = 3;
                var expectedItem3 = 5;

                // Act
                list.AddItem(1);
                list.AddItem(3);
                list.AddItem(5);

                // Assert
                var actualItem1 = list[0];
                var actualItem2 = list[1];
                var actualItem3 = list[2];

                Assert.AreEqual(expectedItem1, actualItem1, "");
                Assert.AreEqual(expectedItem2, actualItem2, "");
                Assert.AreEqual(expectedItem3, actualItem3, "");
            }

            [TestMethod]
            public void AddFirst()
            {
                // Arrange
                var list = new SingleLinkedArrayListGeneric<int>();
                var expectedItem1 = 1;

                // Act
                list.AddItem(3);
                list.AddFirst(1);
                list.AddItem(5);

                // Assert
                var actualItem1 = list[0];

                Assert.AreEqual(expectedItem1, actualItem1, "");
            }

            [TestMethod]
            public void AddLast()
            {
                // Arrange
                var list = new SingleLinkedArrayListGeneric<int>();
                var expected = 5;

                // Act
                list.AddItem(1);
                list.AddItem(3);
                list.AddLast(5);

                // Assert
                var actual = list[2];

                Assert.AreEqual(expected, actual, "");
            }

        }

        [TestClass]
        public class Remove
        {
            [TestMethod]
            public void RemoveNode()
            {
                // Arrange
                var list = new SingleLinkedArrayListGeneric<int>();
                var expected = false;

                // Act
                list.AddItem(1);
                list.AddItem(3);
                list.AddItem(5);

                list.RemoveNode(3);

                // Assert
                var actual = list.Contains(3);

                Assert.AreEqual(expected, actual, "");
            }

        }
    }
}