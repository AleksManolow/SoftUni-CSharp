using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Basketball
{
    public class Team
    {
        public string Name{ get; set; }
        public int OpenPositions{ get; set; }
        public char Group{ get; set; }
        public List<Player> Players { get; set; }
        public int Count { get { return this.Players.Count; } }
        public Team(string name, int openPositions, char group)
        {
            this.Name = name;
            this.OpenPositions = openPositions;
            this.Group = group;
            this.Players = new List<Player>();
        }
        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            else if (this.OpenPositions <= 0)
            {
                return "There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            Players.Add(player);
            this.OpenPositions--;
            return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            Player player = this.Players.SingleOrDefault(x => x.Name == name);
            if (player == null) return false;
            OpenPositions++;
            this.Players.Remove(player);
            return true;
        }

        public int RemovePlayerByPosition(string position)
        {
            int count = this.Players.RemoveAll(x => x.Position == position);
            this.OpenPositions += count;
            return count;
        }

        public Player RetirePlayer(string name)
        {
            Player player = this.Players.SingleOrDefault(x => x.Name == name);
            if (player == null) 
                return null;

            player.Retired = true;
            return player;
        }

        public List<Player> AwardPlayers(int games)
        {
            return this.Players.Where(x => x.Games >= games).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active Players competing for Team {Name} from Group {Group}:");
            foreach (var player in Players)
            {
                if (!player.Retired)
                {
                    sb.AppendLine(player.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
