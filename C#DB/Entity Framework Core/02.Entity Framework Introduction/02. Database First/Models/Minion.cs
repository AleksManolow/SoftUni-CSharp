using System;
using System.Collections.Generic;

namespace SoftUni.Models
{
    public partial class Minion
    {
        public Minion()
        {
            Villains = new HashSet<Villain>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public int? TownId { get; set; }

        public virtual Town? Town { get; set; }

        public virtual ICollection<Villain> Villains { get; set; }
    }
}
