namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        [Test]
        public void ValidateCtorAndProp()
        {
            Aquarium aquarium = new Aquarium("Sea", 12);

            Assert.IsNotNull(aquarium);

            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 15));
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 15));
            Assert.Throws<ArgumentException>(() => new Aquarium("Sea", -2));
        }
        [Test]
        public void ValidateMethotAdd() 
        {
            Aquarium aquarium = new Aquarium("Sea", 1);
            aquarium.Add(new Fish("Pesho"));

            Assert.AreEqual(1, aquarium.Count);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Gosho")));

        }
        [Test]
        public void ValidateMethotRemove() 
        {
            Aquarium aquarium = new Aquarium("Sea", 1);
            aquarium.Add(new Fish("Pesho"));

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Gosho"));

            aquarium.RemoveFish("Pesho");
            Assert.AreEqual(0, aquarium.Count);
        }
        [Test]
        public void ValidateMethotSellFish() 
        {
            Aquarium aquarium = new Aquarium("Sea", 1);
            aquarium.Add(new Fish("Pesho"));

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Gosho"));

            Fish fish = aquarium.SellFish("Pesho");

            Assert.AreEqual(false, fish.Available);
        }
        [Test]
        public void ValidateMethotReport() 
        {
            Aquarium aquarium = new Aquarium("Sea", 1);
            aquarium.Add(new Fish("Pesho"));

            Assert.AreEqual($"Fish available at Sea: Pesho", aquarium.Report());
        }
        
    }
}
