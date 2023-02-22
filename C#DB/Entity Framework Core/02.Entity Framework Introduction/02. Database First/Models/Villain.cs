using System;
using System.Collections.Generic;

namespace SoftUni.Models
{
    public partial class Villain
    {
        public Villain()
        {
            Minions = new HashSet<Minion>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? EvilnessFactorId { get; set; }

        public virtual EvilnessFactor? EvilnessFactor { get; set; }

        public virtual ICollection<Minion> Minions { get; set; }
    }
}
