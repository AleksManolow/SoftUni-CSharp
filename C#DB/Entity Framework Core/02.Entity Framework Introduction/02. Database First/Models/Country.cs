﻿using System;
using System.Collections.Generic;

namespace _02._Database_First.Models
{
    public partial class Country
    {
        public Country()
        {
            Towns = new HashSet<Town>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}
