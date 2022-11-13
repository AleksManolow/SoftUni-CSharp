namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void WarriorDamageShouldNotBe0OrLess(int damage)
        {
            Assert.That(() => new Warrior("Alex", damage, 100),
                Throws.ArgumentException.With.Message
                    .EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void WarriorHealthShouldNotBeNegative()
        {
            Assert.That(() => new Warrior("Alex", 50, -10),
                Throws.ArgumentException.With.Message
                    .EqualTo("HP should not be negative!"));
        }

        [Test]
        public void ConstructorShouldCreateValidWarriorWithValidData()
        {
            Warrior warrior = new Warrior("Alex", 50, 100);

            Assert.That(warrior.Name == "Alex");
            Assert.That(warrior.Damage == 50);
            Assert.That(warrior.HP == 100);
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
