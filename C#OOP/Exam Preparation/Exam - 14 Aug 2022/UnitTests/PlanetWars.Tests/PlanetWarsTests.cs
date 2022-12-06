using NUnit.Framework;
using System;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test] 
            public void ValidateCtorAndProp()
            {
                //Weapon
                Assert.Throws<ArgumentException>(() => new Weapon("AK47", -2, 2));
                Weapon weaponOne = new Weapon("AK47", 200, 2);
                weaponOne.IncreaseDestructionLevel();
                Assert.AreEqual(3, weaponOne.DestructionLevel);
                Assert.IsFalse(weaponOne.IsNuclear);

                Weapon weaponTwo = new Weapon("AK47", 200, 11);
                Assert.IsTrue(weaponTwo.IsNuclear);

                //Planet
                Planet planet = new Planet("Zemq", 1000);
                Assert.IsNotNull(planet);

                var type = typeof(Planet);
                PropertyInfo propertyInfo = type.GetProperty("Weapons");
                Assert.That(propertyInfo.CanWrite == false);

                Assert.Throws<ArgumentException>(() => new Planet(null, 1000));
                Assert.Throws<ArgumentException>(() => new Planet("", 1000));
                Assert.Throws<ArgumentException>(() => new Planet("Zemq", -1000));

                Weapon weapon1 = new Weapon("AK47", 700, 5);
                Weapon weapon2 = new Weapon("Makrow", 400, 3);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                Assert.AreEqual(8, planet.MilitaryPowerRatio);
            }
            [Test]
            public void ValidateMethotProfit()
            {
                Planet planet = new Planet("Zemq", 1000);
                planet.Profit(200);
                Assert.AreEqual(1200, planet.Budget);
            }
            [Test]
            public void ValidateMethotSpendFunds() 
            {
                Planet planet = new Planet("Zemq", 1000);
                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(1001));

                planet.SpendFunds(120);
                Assert.AreEqual(880, planet.Budget);
            }
            [Test]
            public void ValidateMethotAddWeapon() 
            {
                Planet planet = new Planet("Zemq", 2000);
                Weapon weaponOne = new Weapon("AK47", 700, 5);
                Weapon weaponTwo = new Weapon("Makrow", 400, 3);

                planet.AddWeapon(weaponOne);
                planet.AddWeapon(weaponTwo);

                Assert.AreEqual(2, planet.Weapons.Count);

                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(new Weapon("AK47", 150, 7)));
            }
            [Test]
            public void ValidateMethotRemoveWeapon()
            {
                Planet planet = new Planet("Zemq", 2000);
                Weapon weaponOne = new Weapon("AK47", 700, 5);
                Weapon weaponTwo = new Weapon("Makrow", 400, 3);

                planet.AddWeapon(weaponOne);
                planet.AddWeapon(weaponTwo);

                planet.RemoveWeapon("AK47");

                Assert.AreEqual(1, planet.Weapons.Count);

                planet.RemoveWeapon("Makrow");


                Assert.AreEqual(0, planet.Weapons.Count);
            }
            [Test]
            public void ValidateMethotUpgradeWeapon()
            {
                Planet planet = new Planet("Zemq", 2000);
                Weapon weaponOne = new Weapon("AK47", 700, 5);
                Weapon weaponTwo = new Weapon("Makrow", 400, 3);

                planet.AddWeapon(weaponOne);
                planet.AddWeapon(weaponTwo);

                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("MP5"));

                planet.UpgradeWeapon("AK47");

                Assert.AreEqual(6, weaponOne.DestructionLevel);

            }
            [Test]
            public void ValidateMethotDestructOpponent() 
            {
                Planet planetOne = new Planet("Zemq", 2000);
                Weapon weaponOne1 = new Weapon("AK47", 700, 5);
                Weapon weaponTwo1 = new Weapon("Makrow", 400, 3);

                planetOne.AddWeapon(weaponOne1);
                planetOne.AddWeapon(weaponTwo1);

                Planet planetTwo = new Planet("Upiter", 2000);
                Weapon weaponOne2 = new Weapon("FAD", 500, 9);
                Weapon weaponTwo2 = new Weapon("MG36", 450, 4);

                planetTwo.AddWeapon(weaponOne2);
                planetTwo.AddWeapon(weaponTwo2);

                Assert.Throws<InvalidOperationException>(() => planetOne.DestructOpponent(planetTwo));

                Weapon weaponThree1 = new Weapon("P90", 400, 9);
                planetOne.AddWeapon(weaponThree1);

                Assert.AreEqual($"Upiter is destructed!", planetOne.DestructOpponent(planetTwo));
            }
        }
    }
}
