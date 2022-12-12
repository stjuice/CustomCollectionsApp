using CustomCollections.ArrayLists;

namespace CustomCollections.Tests;

[TestClass]
public class ArrayListTests
{
    [TestClass]
    public class CreateArrayListTests
    {
        [TestMethod]
        public void CreateArrayList_Empty()
        {
            // Arrange
            var expected = 0;

            // Act
            var arrayList = new ArrayListT();

            // Assert
            var actual = arrayList.Count;
            Assert.AreEqual(expected, actual, "Count of array list should eaqual 0"); // grammar
        }

        [TestMethod]
        public void CreateArrayList_WithSize()
        {
            // Arrange
            var expected = 6;

            // Act
            var arrayList = new ArrayListT(6);

            // Assert
            var actual = arrayList.Count;
            Assert.AreEqual(expected, actual, "Count of array list should eaqual 6"); // grammar
        }

        [TestMethod]
        public void CreateArrayList_WithItems()
        {
            // Arrange
            var expected = 4;
            var items = new int[] { 1, 3, 5, 7 };

            // Act
            var arrayList = new ArrayListT(items);

            // Assert
            var actual = arrayList.Count;
            Assert.AreEqual(expected, actual, "Count of array list should eaqual 4"); // grammar
        }

        [TestMethod]
        public void CreateArrayList_WithArrayList()
        {
            // Arrange
            var expected = 4;
            var items = new object[] { 1, "Blue", 5, 7 };
            var arrayList = new ArrayListT(items);

            // Act
            var fromArrayList = new ArrayListT(arrayList);

            // Assert
            var actual = fromArrayList.Count;
            Assert.AreEqual(expected, actual, "Count of array list should eaqual 4"); // grammar
        }
    }

    [TestClass]
    public class AddItemsTests
    {
        [TestMethod]
        public void AddItem_Int()
        {
            // Arrange
            var arrayList = new ArrayListT();
            var expected = 1;

            // Act
            arrayList.Add(1);

            // Assert
            var actual = arrayList[0];
            Assert.AreEqual(expected, actual, "Item of int type was added");
        }

        [TestMethod]
        public void AddItem_String()
        {
            // Arrange
            var arrayList = new ArrayListT();
            var expected = "Blue";

            // Act
            arrayList.Add("Blue");

            // Assert
            var actual = arrayList[0];
            Assert.AreEqual(expected, actual, "");
        }

        [TestMethod]
        public void AddItems_SingleType()
        {
            // Arrange
            var arrayList = new ArrayListT();
            var expectedFirst = 1;
            var expectedSecond = 2;
            var expectedThird = 3;

            // Act
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);

            // Assert
            var actualFirst = arrayList[0];
            var actualSecond = arrayList[1];
            var actualThird = arrayList[2];

            Assert.AreEqual(expectedFirst, actualFirst, "");
            Assert.AreEqual(expectedSecond, actualSecond, "");
            Assert.AreEqual(expectedThird, actualThird, "");
        }


        [TestMethod]
        public void AddItems_MultipleTypes()
        {
            // Arrange
            var time = new DateTime(2022, 2, 23);
            var arrayList = new ArrayListT();
            var expectedFirst = 1;
            var expectedSecond = "Blue";
            var expectedThird = time;

            // Act
            arrayList.Add(1);
            arrayList.Add("Blue");
            arrayList.Add(time);

            // Assert
            var actualFirst = arrayList[0];
            var actualSecond = arrayList[1];
            var actualThird = arrayList[2];

            Assert.AreEqual(expectedFirst, actualFirst, "");
            Assert.AreEqual(expectedSecond, actualSecond, "");
            Assert.AreEqual(expectedThird, actualThird, "");
        }
    }

    [TestClass]
    public class RemoveItemTests
    {
        static readonly object[] items = new object[] { 1, "Blue", 5, 7 };
        readonly ArrayListT arrayList = new(items);

        [TestMethod]
        public void RemoveItem_ByValue()
        {
            // Arrange
            var expectedCount = 3;
            var expected = -1;

            // Act
            arrayList.Remove(5);

            // Assert
            var actualCount = arrayList.Count;
            var actual = arrayList.IndexOf(5);

            Assert.AreEqual(expectedCount, actualCount, "");
            Assert.AreEqual(expected, actual, "");
        }

        [TestMethod]
        public void RemoveItem_ByIndex()
        {
            // Arrange
            var expectedCount = 3;
            var expected = -1;

            // Act
            arrayList.RemoveAt(3);

            // Assert
            var actualCount = arrayList.Count;
            var actual = arrayList.IndexOf(7);

            Assert.AreEqual(expectedCount, actualCount, "");
            Assert.AreEqual(expected, actual, "");
        }
    }
}