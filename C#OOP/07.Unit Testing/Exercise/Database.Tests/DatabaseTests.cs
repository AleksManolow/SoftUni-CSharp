namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(1, 4)]
        [TestCase(1, 15)]
        [TestCase(1, 16)]
        public void ConstructorShouldAddElementsWhileLessThan16(int start, int end)
        {
            Database database = new Database(Enumerable.Range(start, end).ToArray());
            Assert.AreEqual(end, database.Count);
        }

        [TestCase(1, 17)]
        public void ConstructorShouldThrowExceptionWhenAddingMoreThan17Items(int start, int end)
        {

            Assert.Throws<InvalidOperationException>(
                () => new Database(Enumerable.Range(start, end).ToArray()));
        }
        [TestCase(5)]
        [TestCase(8)]
        [TestCase(16)]
        public void AddMethodShouldAddNewItemWhileCountLessThan16(int count)
        {
            Database database = new Database();
            for (int i = 0; i < count; i++)
            {
                database.Add(i);
            }
            Assert.AreEqual(count, database.Count);
        }
        [Test]
        public void AddMethodShouldThrowExceptionWhenAddingMoreThan17Items()
        {
            Database database = new Database(Enumerable.Range(1, 16).ToArray());

            Assert.Throws<InvalidOperationException>(() => database.Add(1));
        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        public void RemoveShouldRemoveItemsWhenCollectionHasMoreThan0Elements(int count)
        {
            Database database = new Database(Enumerable.Range(1, count).ToArray());

            database.Remove();

            Assert.AreEqual(count - 1, database.Count);
        }
        [Test]
        public void RemoveShouldThrowExceptionWhenCollectionHas0Elements()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(
                () => database.Remove());
        }
        [Test]
        public void FetchShouldReturnAllValidItems()
        {
            Database database = new Database(1, 2, 3);
            database.Add(4);
            database.Add(5);
            database.Add(6);

            database.Remove();
            database.Remove();

            int[] fetched = database.Fetch();
            int[] expectedData = new int[] { 1, 2, 3, 4 };

            CollectionAssert.AreEqual(fetched, expectedData);
        }

    }
}
