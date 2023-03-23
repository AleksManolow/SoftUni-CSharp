﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Guns = new HashSet<Gun>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(40)]
        public string ManufacturerName { get; set; } = null!;
        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Founded { get; set; } = null!;

        public virtual ICollection<Gun> Guns { get; set; }
    }
}
