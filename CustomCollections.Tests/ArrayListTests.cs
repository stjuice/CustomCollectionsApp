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
            var expected = 0;

            var arrayList = new ArrayListT();

            var actual = arrayList.Count;
            Assert.AreEqual(expected, actual, "");
        }

        [TestMethod]
        public void CreateArrayList_WithSize()
        {
            var expected = 6;

            var arrayList = new ArrayListT(6);

            var actual = arrayList.Count;
            Assert.AreEqual(expected, actual, "");
        }

        [TestMethod]
        public void CreateArrayList_WithItems()
        {
            var expected = 4;
            var items = new int[] { 1, 3, 5, 7 };

            var arrayList = new ArrayListT(items);

            var actual = arrayList.Count;
            Assert.AreEqual(expected, actual, "");
        }

        [TestMethod]
        public void CreateArrayList_WithArrayList()
        {
            var expected = 4;
            var items = new object[] { 1, "Blue", 5, 7 };
            var arrayList = new ArrayListT(items);

            var fromArrayList = new ArrayListT(arrayList);

            var actual = fromArrayList.Count;
            Assert.AreEqual(expected, actual, "");
        }
    }

    [TestClass]
    public class AddItemsTests
    {
        [TestMethod]
        public void AddItem_Int()
        {
            var arrayList = new ArrayListT();
            var expected = 1;

            arrayList.Add(1);

            var actual = arrayList[0];
            Assert.AreEqual(expected, actual, "");
        }

        [TestMethod]
        public void AddItem_String()
        {
            var arrayList = new ArrayListT();
            var expected = "Blue";

            arrayList.Add("Blue");

            var actual = arrayList[0];
            Assert.AreEqual(expected, actual, "");
        }

        [TestMethod]
        public void AddItems_SingleType()
        {
            var arrayList = new ArrayListT();
            var expectedFirst = 1;
            var expectedSecond = 2;
            var expectedThird = 3;

            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);

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
            var time = new DateTime(2022, 2, 23);
            var arrayList = new ArrayListT();
            var expectedFirst = 1;
            var expectedSecond = "Blue";
            var expectedThird = time;

            arrayList.Add(1);
            arrayList.Add("Blue");
            arrayList.Add(time);

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
            var expectedCount = 3;
            var expected = -1;

            arrayList.Remove(5);

            var actualCount = arrayList.Count;
            var actual = arrayList.IndexOf(5);

            Assert.AreEqual(expectedCount, actualCount, "");
            Assert.AreEqual(expected, actual, "");
        }

        [TestMethod]
        public void RemoveItem_ByIndex()
        {
            var expectedCount = 3;
            var expected = -1;

            arrayList.RemoveAt(3);

            var actualCount = arrayList.Count;
            var actual = arrayList.IndexOf(7);

            Assert.AreEqual(expectedCount, actualCount, "");
            Assert.AreEqual(expected, actual, "");
        }
    }
}