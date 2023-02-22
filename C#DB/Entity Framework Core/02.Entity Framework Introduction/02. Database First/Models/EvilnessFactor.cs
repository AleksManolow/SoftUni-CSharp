using System;
using System.Collections.Generic;

namespace _02._Database_First.Models
{
    public partial class EvilnessFactor
    {
        public EvilnessFactor()
        {
            Villains = new HashSet<Villain>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Villain> Villains { get; set; }
    }
}
