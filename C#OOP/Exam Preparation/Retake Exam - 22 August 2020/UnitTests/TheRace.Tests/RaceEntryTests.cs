using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [Test]
        public void ValidateCtorAndProp()
        {
            RaceEntry raceEntry = new RaceEntry();
            Assert.IsNotNull(raceEntry);

            Assert.Throws<ArgumentNullException> (() =>new UnitDriver(null, new UnitCar("Astra", 101, 20000)));
        }
        [Test]
        public void ValidateMethotAdd() 
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));

            UnitDriver unitDriver1 = new UnitDriver("Gosho", new UnitCar("Astra", 101, 20000));
            raceEntry.AddDriver(unitDriver1);

            Assert.AreEqual(1, raceEntry.Counter);

            UnitDriver unitDriver2 = new UnitDriver("Gosho", new UnitCar("Astra", 101, 20000));
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(unitDriver2));

            UnitDriver unitDriver3 = new UnitDriver("Pesho", new UnitCar("Corsa", 91, 1500));
            Assert.AreEqual("Driver Pesho added in race.", raceEntry.AddDriver(unitDriver3));
            Assert.AreEqual(2, raceEntry.Counter);
        }
        [Test]
        public void ValidateMethotCalculateAverageHorsePower()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitDriver unitDriver1 = new UnitDriver("Gosho", new UnitCar("Astra", 101, 20000));
            raceEntry.AddDriver(unitDriver1);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());

            UnitDriver unitDriver2 = new UnitDriver("Pesho", new UnitCar("Corsa", 91, 1500));
            raceEntry.AddDriver(unitDriver2);

            Assert.AreEqual(96, raceEntry.CalculateAverageHorsePower());
        }
    }
}