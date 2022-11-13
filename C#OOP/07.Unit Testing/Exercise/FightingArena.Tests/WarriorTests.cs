namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test] 
        public void ConstructorShouldCreateObjectWithValidData()
        {
            Warrior warrior = new Warrior("Varus", 150, 1000);
            Assert.AreEqual("Varus", warrior.Name);
            Assert.AreEqual(150, warrior.Damage);
            Assert.AreEqual(1000, warrior.HP);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void NamePropertyShouldThrowExceptionWhenInvalidDataIsSet(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 150, 1000));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-154)]
        public void DamagePropertyShouldThrowExceptionWhenInvalidDataIsSet(int demage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Varus", demage, 1000));
        }
        [Test]
        public void HPPropertyShouldThrowExceptionWhenInvalidDataIsSet()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Varus", 145, -4561));
        }
        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void AttackMethodShouldThrowExceptionIfWarriorHpLessOrEqualToMinHp(int HP)
        {
            Warrior warrior = new Warrior("Alex", 50, HP);
            Warrior enemy = new Warrior("Bpbby", 50, 50);

            Assert.That(() => warrior.Attack(enemy),
                Throws.InvalidOperationException.With.Message
                    .EqualTo("Your HP is too low in order to attack other warriors!"));
        }
        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void AttackMethodShouldThrowExceptionIfEnemyHpLessOrEqualToMinHp(int HP)
        {
            Warrior warrior = new Warrior("Alex", 50, 50);
            Warrior enemy = new Warrior("Bpbby", 50, HP);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
        }

        [Test]
        public void AttackMethodShouldThrowExceptionIfWarriorHpLessThanEnemyDamage()
        {
            Warrior warrior = new Warrior("Alex", 50, 50);
            Warrior enemy = new Warrior("Bpbby", 60, 50);

            Assert.That(() => warrior.Attack(enemy),
                Throws.InvalidOperationException.With.Message
                    .EqualTo($"You are trying to attack too strong enemy"));
        }

        [Test]
        public void AttackMethodShouldReduceWarriorHp()
        {
            Warrior warrior = new Warrior("Alex", 70, 100);
            Warrior enemy = new Warrior("Bpbby", 50, 50);

            warrior.Attack(enemy);

            Assert.That(warrior.HP, Is.EqualTo(50));
        }

        [Test]
        public void AttackMethodShouldReduceEnemyHp()
        {
            Warrior warrior = new Warrior("Alex", 50, 100);
            Warrior enemy = new Warrior("Bobby", 50, 70);

            warrior.Attack(enemy);

            Assert.That(enemy.HP, Is.EqualTo(20));
        }
    }
}