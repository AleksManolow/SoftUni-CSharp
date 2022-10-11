using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public Hero(string name, int level)
        {
            this.Name = name;
            this.Level = level;
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Name} Level: {this.Level}";
        }

    }
}
