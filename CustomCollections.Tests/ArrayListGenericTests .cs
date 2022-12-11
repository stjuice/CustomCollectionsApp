using CustomCollections.ArrayList;

namespace CustomCollections.Tests;

[TestClass]
public class ArrayListGenericTests 
{
    [TestClass]
    public class CreateArrayListTests
    {
        static readonly int[] items = new int[] { 1, 3, 5, 7 };
        readonly ArrayListGeneric<int> arrayList = new(items);

        [TestMethod]
        public void Clear()
        {
            // Arrange
            var expected = 0;
            var itemExpected = 0;

            // Act
            arrayList.Clear();

            // Assert
            var actual = arrayList.Count;

            var actualItem0 = arrayList[0];
            var actualItem1 = arrayList[1];
            var actualItem2 = arrayList[2];
            var actualItem3 = arrayList[3];



            Assert.AreEqual(expected, actual, "");

            Assert.AreEqual(itemExpected, actualItem0, "");
            Assert.AreEqual(itemExpected, actualItem1, "");
            Assert.AreEqual(itemExpected, actualItem2, "");
            Assert.AreEqual(itemExpected, actualItem3, "");

        }
    }

    [TestClass]
    public class InsertItem
    {
        static readonly string[] items = new string[] { "b", "y", "r", "w" };
        readonly ArrayListGeneric<string> arrayList = new(items);

        [TestMethod]
        public void Insert()
        {
            // Arrange
            var expected = "t";
            var expectedSize = 5;

            // Act
            arrayList.Insert(2, "t");

            // Assert
            var actual = arrayList[2];
            var actualSize = arrayList.Count;

            Assert.AreEqual(expected, actual, "");
            Assert.AreEqual(expectedSize, actualSize, "");
        }
    }
}