namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void EmptyConstructorShouldSetFuelAmountTo0()
        {
            Car car = new Car("Audi", "RS6", 0.7, 50);
            Assert.AreEqual(0, car.FuelAmount);
        }
        [Test]
        public void ConstructorShouldCreateObjectWithValidData()
        {
            Car car = new Car("Audi", "RS6", 0.7, 50);
            Assert.AreEqual("Audi", car.Make);
            Assert.AreEqual("RS6", car.Model);
            Assert.AreEqual(0.7, car.FuelConsumption);
            Assert.AreEqual(50, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void MakePropertyShouldThrowExceptionWhenInvalidDataIsSet(string make)
        {
            Assert.Throws<ArgumentException>
            (
                () => new Car(make, "RS6", 0.7, 50)
            );
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ModelPropertyShouldThrowExceptionWhenInvalidDataIsSet(string model)
        {
            Assert.Throws<ArgumentException>
            (
                () => new Car("Audi", model, 0.7, 50)
            );
        }
        [Test]
        public void FuelConsumptionPropertyShouldThrowExceptionWhenInvalidDataIsSet()
        {
            Assert.Throws<ArgumentException>
            (
                () => new Car("Audi", "RS7", -0.5, 50)
            );
        }
        [Test]
        [TestCase(-0)]
        [TestCase(-0.2)]
        [TestCase(0)]
        public void FuelCapacityPropertyShouldThrowExceptionWhenInvalidDataIsSet(double capacity)
        {
            Assert.Throws<ArgumentException>
            (
                () => new Car("Audi", "RS7", 0.7, capacity)
            );
        }
        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        [TestCase(-15.6)]
        public void RefuelMethodShouldThrowExceptionIfFuelLessOrEqualTo0(double fuelToRefuel)
        {
            Car car = new Car("Audi", "RS6", 0.7, 50);
            Assert.Throws<ArgumentException>
            (
                () => car.Refuel(fuelToRefuel)
            ); 
        }
        [Test]
        [TestCase(60)]
        [TestCase(10)]
        public void RefuelMethodShouldIncreaseFuelAmount(double fuel)
        {
            Car car = new Car("Audi", "RS6", 0.7, 60);
            double fuelBefore = car.FuelAmount;
            car.Refuel(fuel);

            Assert.AreEqual(car.FuelAmount, fuel + fuelBefore);
        }
        [Test]
        public void RefuelMethodShouldReturnAmountEqualToFuelCapacityWhenFuelExceedsIt()
        {
            Car car = new Car("Audi", "RS6", 0.7, 60);
            car.Refuel(70);

            Assert.AreEqual(car.FuelAmount, car.FuelCapacity);
        }
        [Test]
        public void DriveMethodShouldReduceFuelAmountIfEnoughFuel()
        {
            Car car = new Car("Audi", "RS6", 7, 60);
            car.Refuel(60);
            car.Drive(50);

            Assert.AreEqual(56.5, car.FuelAmount);
        }
        [Test]
        public void DriveMethodShouldThrowExceptionWhenFuelNotEnoughToDriveCar()
        {
            Car car = new Car("Opel", "Astra", 7, 60);

            Assert.That(() => car.Drive(5), Throws.InvalidOperationException.With.Message.EqualTo("You don't have enough fuel to drive!"));
        }


    }
}