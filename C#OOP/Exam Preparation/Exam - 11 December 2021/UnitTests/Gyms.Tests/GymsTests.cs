using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        public void ValidateCtorAndProp() 
        {
            Gym gym = new Gym("Athletic", 45);
            Assert.IsNotNull(gym);

            Assert.Throws<ArgumentNullException>(() => new Gym(null, 45));
            Assert.Throws<ArgumentNullException>(() => new Gym("", 45));
            Assert.Throws<ArgumentException>(() => new Gym("Athletic", -5));
        }
        [Test]
        public void ValidateMethotAddAthlete()
        {
            Gym gym = new Gym("Athletic", 1);
            Athlete athlete1 = new Athlete("Gosho");
            Athlete athlete2 = new Athlete("Pesho");

            gym.AddAthlete(athlete1);
            Assert.AreEqual(1, gym.Count);
            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete2));
        }
        [Test]
        public void ValidateMethotRemoveAthlete()
        {
            Gym gym = new Gym("Athletic", 15);
            Athlete athlete1 = new Athlete("Gosho");
            Athlete athlete2 = new Athlete("Pesho");
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);

            gym.RemoveAthlete("Pesho");
            Assert.AreEqual(1, gym.Count);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Kosta"));
        }
        [Test]
        public void ValidateMethotInjureAthlete()
        {
            Gym gym = new Gym("Athletic", 15);
            Athlete athlete1 = new Athlete("Gosho");
            Athlete athlete2 = new Athlete("Pesho");
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);

            
            Assert.AreEqual(athlete1, gym.InjureAthlete("Gosho"));

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Kosta"));
        }
        [Test]
        public void ValidatemethotReport()
        {
            Gym gym = new Gym("Athletic", 15);
            Athlete athlete1 = new Athlete("Gosho");
            Athlete athlete2 = new Athlete("Pesho");
            athlete2.IsInjured = true;
            Athlete athlete3 = new Athlete("Kosta");
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);

            string output = "Active athletes at Athletic: Gosho, Kosta";
            Assert.AreEqual(output, gym.Report());
        }
    }
}
