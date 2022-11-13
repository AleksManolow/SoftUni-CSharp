using System;
using ExtendedDatabase;
namespace DatabaseExtended.Tests
{
    using NUnit.Framework;
    using System.Drawing;
    using System.Text;
    using System.Xml.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [TestCase(5)]
        [TestCase(8)]
        [TestCase(15)]
        public void ConstructorShouldAddPeopleToDatabaseIfCollectionLessOrEqualTo16(int count)
        {
            Person[] people = new Person[count];
            for (int i = 0; i < count; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Aleks");
                sb.Append(i.ToString());

                people[i] = new Person(1234 + i, sb.ToString());
            }

            Database database = new Database(people);
            Assert.AreEqual(count, database.Count);
        }
        [Test]
        public void ConstructorShouldThrowExceptionWhenCollectionExceeds16()
        {
            Person[] people = new Person[20];
            for (int i = 0; i < 16; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Aleks");
                sb.Append(i.ToString());

                people[i] = new Person(1234 + i, sb.ToString());
            }
            Assert.Throws<ArgumentException> ( () => new Database(people));
        }
        [Test]
        public void AddMethodShouldThrowExceptionWhenAddingExistingPersonById()
        {
            Person person = new Person(1324, "Gosho");
            Database database= new Database(person);
            Assert.Throws<InvalidOperationException>(
                () => database.Add(new Person(1324, "Pesho")));
        }
        [Test]
        public void AddMethodShouldThrowExceptionWhenAddingExistingPersonByName()
        {
            Person person = new Person(13424, "Gosho");
            Database database = new Database(person);
            Assert.Throws<InvalidOperationException>(
                () => database.Add(new Person(1233, "Gosho")));
        }
        [Test]
        public void AddMethodShouldThrowExceptionIfCollectionHas16People()
        {
            Person[] people = new Person[16];
            for (int i = 0; i < 16; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Aleks");
                sb.Append(i.ToString());

                people[i] = new Person(1234 + i, sb.ToString());
            }
            Database database= new Database(people);
            Assert.Throws<InvalidOperationException>(
                () => database.Add(new Person(2233, "Gosho")));
        }
        [Test]
        public void RemoveMethodShouldThrowExceptionIfDatabaseIsEmpty()
        {
            Database database = new Database();
            Assert.Throws<InvalidOperationException>(
                () => database.Remove());
        }
        [Test]
        public void RemoveMethodShouldRemoveElementsFromDatabase()
        {
            Database database = new Database();
            database.Add(new Person(132, "Aleks"));
            database.Add(new Person(465, "Pesho"));

            database.Remove();

            Assert.AreEqual(1, database.Count);
        }
        [TestCase(null)]
        [TestCase("")]
        public void FindByUsernameMethodShouldThrowExceptionIfInvalidUsername(string name)
        {
            Person person = new Person(1324,"Aleks");
            Database database = new Database(person);
            Assert.Throws<ArgumentNullException>(
                () => database.FindByUsername(name));
        }
        [TestCase("Gosho")]
        [TestCase("Iv4o")]
        public void FindByUsernameMethodShouldThrowExceptionIfLowercaseName(string name)
        {
            Person person = new Person(1324, "Aleks");
            Database database = new Database(person);
            Assert.Throws<InvalidOperationException>(
                () => database.FindByUsername(name));
        }
        [Test]
        public void FindByUsernameMethodShouldThrowExceptionIfUsernameDoesNotExist()
        {
            Person person = new Person(1324, "Aleks");
            Database database = new Database(person);
            Assert.Throws<InvalidOperationException>(
                () => database.FindByUsername("Qwor"));
        }
        [Test]
        public void FindByUsernameShouldReturnPersonWithThatUsername()
        {
            Database fullDatabase = new Database();
            Person expected = new Person(1234, "Iva0");
            fullDatabase.Add(expected);
            Person result = fullDatabase.FindByUsername("Iva0");
            

            Assert.AreEqual((result.UserName, result.Id), (expected.UserName, expected.Id));
        }
        [Test]
        public void FindByIdMethodShouldThrowExceptionIfNoUserWithThatIdInDatabase()
        {
            Person[] people = new Person[16];
            for (int i = 0; i < 16; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Aleks");
                sb.Append(i.ToString());

                people[i] = new Person(1234 + i, sb.ToString());
            }
            Database database = new Database(people);

            Assert.Throws<InvalidOperationException>(() => database.FindById(12));
        }
        [Test]
        public void FindByIdMethodShouldThrowExceptionIfNegativeIdIsProvided()
        {
            Person[] people = new Person[16];
            for (int i = 0; i < 16; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Aleks");
                sb.Append(i.ToString());

                people[i] = new Person(1234 + i, sb.ToString());
            }
            Database database = new Database(people);

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-12));
        }
        [Test]
        public void FindByIdShouldReturnPersonWithThatId()
        {
            Person[] people = new Person[16];
            for (int i = 0; i < 16; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Aleks");
                sb.Append(i.ToString());

                people[i] = new Person(1234 + i, sb.ToString());
            }
            Database database = new Database(people);

            Person expected = new Person(1235, "Aleks1");
            Person result = database.FindById(1235);
            Assert.AreEqual((result.Id, result.UserName),
                (expected.Id, expected.UserName));
        }
    }
}