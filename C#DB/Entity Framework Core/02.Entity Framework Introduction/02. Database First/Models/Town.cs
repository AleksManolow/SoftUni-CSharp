using System;
using System.Collections.Generic;

namespace SoftUni.Models
{
    public partial class Town
    {
        public Town()
        {
            Minions = new HashSet<Minion>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CountryCode { get; set; }

        public virtual Country? CountryCodeNavigation { get; set; }
        public virtual ICollection<Minion> Minions { get; set; }
    }
}
