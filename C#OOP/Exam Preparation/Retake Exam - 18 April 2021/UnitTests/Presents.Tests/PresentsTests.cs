using System;
using System.Collections.Concurrent;
namespace Presents.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        [Test] 
        public void ValidateCtor() 
        {
            Bag bag = new Bag();
            Assert.IsNotNull(bag);
        }
        [Test]
        public void ValidateMethotCreate() 
        { 
            Bag bag = new Bag();
     
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));

            Present present1 = new Present("Car", 12.5);

            bag.Create(present1);

            Assert.Throws<InvalidOperationException>(() => bag.Create(present1));

            Present present2 = new Present("Box", 12.5);
            Assert.AreEqual("Successfully added present Box.", bag.Create(present2));
        }
        [Test]
        public void ValidateMethotRemove() 
        {
            Bag bag = new Bag();
            Present present1 = new Present("Car", 12.5);
            bag.Create(present1);

            Assert.True(bag.Remove(present1));
        }
        [Test]
        public void ValidateMethotGetPresentWithLeastMagic() 
        {
            Bag bag = new Bag();
            Present present1 = new Present("Car", 22.5);
            Present present2 = new Present("Box", 17.9);
            bag.Create(present1);
            bag.Create(present2);

            Assert.AreEqual(present2, bag.GetPresentWithLeastMagic());
        }
        [Test]
        public void ValidateMethotGetPresent()
        {
            Bag bag = new Bag();
            Present present1 = new Present("Car", 22.5);
            Present present2 = new Present("Box", 17.9);
            bag.Create(present1);
            bag.Create(present2);

            Assert.AreEqual(present1, bag.GetPresent("Car"));
        }
        [Test]
        public void ValidateMethotGetPresents()
        {
            Bag bag = new Bag();

            Present present1 = new Present("Socks", 5.8);
            Present present2 = new Present("Earrings", 10.5);
            Present present3 = new Present("Toy Truck", 15.8);

            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);

            var presents = bag.GetPresents();

            Assert.AreEqual(3, presents.Count);


        }

    }
}
