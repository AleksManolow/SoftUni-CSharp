using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
		private List<Player> players;
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public Team(string name)
		{
			this.Name = name;
            this.players = new List<Player>();
        }

		public double Rating => players.Count == 0
                ? 0
                : Math.Round(players.Average(p => p.SkillLevel));

		public void AddPlayer(Player player)
		{
			players.Add(player);
		}

		public void RemovePlayer(string playerName)
		{
			Player player = players.FirstOrDefault(p => p.Name == playerName);

			if (player == null)
			{
				throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
			}
			players.Remove(player);
		}

    }
}
