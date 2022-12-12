using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [Test]
        public void ValidateCtorAndProp()
        {
            //Football Player
            FootballPlayer footballPlayer = new FootballPlayer("Ronaldo", 7, "Goalkeeper");
            Assert.IsNotNull(footballPlayer);
            Assert.That(0 == footballPlayer.ScoredGoals);

            Assert.Throws<ArgumentException>(() => new FootballPlayer("", 7, "Goalkeeper"));
            Assert.Throws<ArgumentException>(() => new FootballPlayer(null, 7, "Goalkeeper"));
            Assert.Throws<ArgumentException>(() => new FootballPlayer("Ronaldo", 25, "Goalkeeper"));
            Assert.Throws<ArgumentException>(() => new FootballPlayer("Ronaldo", -2, "Goalkeeper"));
            Assert.Throws<ArgumentException>(() => new FootballPlayer("Ronaldo", 7, "Half"));
            Assert.Throws<ArgumentException>(() => new FootballPlayer("Ronaldo", 7, "Back"));

            footballPlayer.Score();
            footballPlayer.Score();
            footballPlayer.Score();
            Assert.That(3 == footballPlayer.ScoredGoals);

            //FootbalTeam
            FootballTeam footballTeam1 = new FootballTeam("Read Madrid", 20);
            Assert.IsNotNull(footballTeam1);

            Assert.Throws<ArgumentException>(() => new FootballTeam(null, 20));
            Assert.Throws<ArgumentException>(() => new FootballTeam("", 20));
            Assert.Throws<ArgumentException>(() => new FootballTeam("Read Madrid", 10));
            Assert.Throws<ArgumentException>(() => new FootballTeam("Read Madrid", -10));

            FootballTeam footballTeam = new FootballTeam("Read Madrid", 15);
            List<FootballPlayer> players = new List<FootballPlayer>();
            Assert.That(footballTeam.Name == "Read Madrid");
            Assert.That(footballTeam.Capacity == 15);
            Assert.That(footballTeam.Players.Count == 0);
            Assert.That(footballTeam.Players != null);
            CollectionAssert.AreEqual(players, footballTeam.Players);
        }
        [Test]
        public void ValidateMethodAddInTeam()
        {
            FootballTeam footballTeam = new FootballTeam("Read Madrid", 17);
            FootballPlayer footballPlayer = new FootballPlayer("Ronaldo", 7, "Goalkeeper");

            string forAddPlayer = "Added player Ronaldo in position Goalkeeper with number 7";
            Assert.That(forAddPlayer == footballTeam.AddNewPlayer(footballPlayer));

            footballTeam.AddNewPlayer(footballPlayer);
            footballTeam.AddNewPlayer(footballPlayer);
            footballTeam.AddNewPlayer(footballPlayer);
            footballTeam.AddNewPlayer(footballPlayer);
            footballTeam.AddNewPlayer(footballPlayer);
            footballTeam.AddNewPlayer(footballPlayer);
            footballTeam.AddNewPlayer(footballPlayer);
            footballTeam.AddNewPlayer(footballPlayer);
            footballTeam.AddNewPlayer(footballPlayer);
            footballTeam.AddNewPlayer(footballPlayer);
            footballTeam.AddNewPlayer(footballPlayer);
            footballTeam.AddNewPlayer(footballPlayer);
            footballTeam.AddNewPlayer(footballPlayer);
            footballTeam.AddNewPlayer(footballPlayer);
            footballTeam.AddNewPlayer(footballPlayer);

            Assert.That(16 == footballTeam.Players.Count);
            footballTeam.AddNewPlayer(footballPlayer);
            Assert.That("No more positions available!" == footballTeam.AddNewPlayer(footballPlayer));
        }
        [Test]
        public void ValidateMethodPickPlayer()
        {
            FootballTeam footballTeam = new FootballTeam("Read Madrid", 15);
            FootballPlayer footballPlayer1 = new FootballPlayer("Ronaldo", 7, "Goalkeeper");
            FootballPlayer footballPlayer2 = new FootballPlayer("Messi", 10, "Forward");
            footballTeam.AddNewPlayer(footballPlayer1);
            footballTeam.AddNewPlayer(footballPlayer2);

            Assert.That(footballPlayer2 == footballTeam.PickPlayer("Messi"));
            Assert.That(null == footballTeam.PickPlayer("Peshkata"));
        }
        [Test]
        public void ValidateMethodPlayerScore() 
        {
            FootballTeam footballTeam = new FootballTeam("Read Madrid", 15);
            FootballPlayer footballPlayer1 = new FootballPlayer("Ronaldo", 7, "Goalkeeper");
            FootballPlayer footballPlayer2 = new FootballPlayer("Messi", 10, "Forward");
            footballTeam.AddNewPlayer(footballPlayer1);
            footballTeam.AddNewPlayer(footballPlayer2);


            Assert.That("Ronaldo scored and now has 1 for this season!" == footballTeam.PlayerScore(7));
            Assert.That("Ronaldo scored and now has 2 for this season!" == footballTeam.PlayerScore(7));
            Assert.That("Messi scored and now has 1 for this season!" == footballTeam.PlayerScore(10));
            Assert.Throws<NullReferenceException>(() => footballTeam.PlayerScore(2));
        }
        
    }
}