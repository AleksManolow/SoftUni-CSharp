using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
            [Test]
            public void ValidateCtorAndProp()
            {
                Garage garage = new Garage("AutoGog", 15);
                Assert.IsNotNull(garage);

                Assert.Throws<ArgumentNullException>(() => new Garage("", 12));
                Assert.Throws<ArgumentNullException>(() => new Garage(null, 12));
                Assert.Throws<ArgumentException>(() => new Garage("AutoGog", 0));
                Assert.Throws<ArgumentException>(() => new Garage("AutoGog", -10));
            }
            [Test]
            public void ValidateMathotAddCar()
            {
                Garage garage = new Garage("AutoGog", 3);

                Car car1 = new Car("Astra", 2);
                Car car2 = new Car("Vektra", 5);

                garage.AddCar(car1);
                garage.AddCar(car2);

                Assert.AreEqual(2, garage.CarsInGarage);

                garage.AddCar(new Car("Corola", 6));

                Assert.Throws<InvalidOperationException>(() => garage.AddCar(new Car("Corsa", 1)));

            }
            [Test]
            public void ValidateMethotFixCar()
            {
                Garage garage = new Garage("AutoGog", 3);

                Car car1 = new Car("Astra", 2);
                Car car2 = new Car("Vektra", 5);

                garage.AddCar(car1);
                garage.AddCar(car2);

                Car tempCar = garage.FixCar("Astra");
                Assert.AreEqual(0, tempCar.NumberOfIssues);

                Assert.Throws<InvalidOperationException>(() => garage.FixCar("Corsa"));
            }
            [Test]
            public void ValidateMethotRemoveFixedCar()
            {
                Garage garage = new Garage("AutoGog", 3);

                Car car1 = new Car("Astra", 0);
                Car car2 = new Car("Vektra", 5);
                Car car3 = new Car("Corsa", 0);

                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());

                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.AddCar(car3);

                Assert.AreEqual(2, garage.RemoveFixedCar());
            }
            [Test]
            public void ValidateMethotReport()
            {

                Garage garage = new Garage("AutoGog", 3);

                Car car1 = new Car("Astra", 0);
                Car car2 = new Car("Vektra", 5);
                Car car3 = new Car("Corsa", 1);

                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.AddCar(car3);

                Assert.AreEqual($"There are 2 which are not fixed: Vektra, Corsa.", garage.Report());
            }
        }
    }
}