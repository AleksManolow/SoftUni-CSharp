namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void ValidateCtorAndProp()
        {
            RobotManager robotManager = new RobotManager(2);

            Assert.AreEqual(2, robotManager.Capacity);

            Assert.IsNotNull(robotManager);

            Assert.Throws<ArgumentException>(() => new RobotManager(-2));

            Assert.AreEqual(0, robotManager.Count);
        }
        [Test]
        public void ValidateMethotAdd()
        {
            RobotManager robotManager = new RobotManager(2);
            Robot robot = new Robot("Pesho", 125);
            robotManager.Add(robot);

            Assert.AreEqual(1, robotManager.Count);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("Pesho", 125)));

            Robot robot1 = new Robot("Sasho", 725);
            robotManager.Add(robot1);
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("Gero", 185)));
        }
        [Test]
        public void ValidateMethotRemove()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Pesho", 125);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("Gosho"));

            robotManager.Remove("Pesho");

            Assert.AreEqual(0, robotManager.Count);
        }
        [Test]
        public void ValidateMethotWork()
        {
            RobotManager robotManager = new RobotManager(2);
            Robot robot1 = new Robot("Pesho", 125);
            Robot robot2 = new Robot("Gosho", 185);
            robotManager.Add(robot1);
            robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Gero", "clean", 18));

            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Gosho", "clean", 189));

            robotManager.Work("Pesho", "Clear", 15);
            Assert.AreEqual(110, robot1.Battery);
        }
        [Test]
        public void ValidateMethotCharge()
        {
            RobotManager robotManager = new RobotManager(2);
            Robot robot1 = new Robot("Pesho", 125);
            Robot robot2 = new Robot("Gosho", 185);
            robotManager.Add(robot1);
            robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("Gero"));

            robotManager.Work("Pesho", "Clear", 15);

            robotManager.Charge("Pesho");

            Assert.AreEqual(125, robot1.Battery);
        }

    }
}
