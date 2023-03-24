﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Theatre.Data.Models.Enums;

namespace Theatre.Data.Models
{
    public class Play
    {
        public Play()
        {
            Casts = new HashSet<Cast>();
            Tickets = new HashSet<Ticket>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Title { get; set; } = null!;
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        [Range(typeof(float), "0.00", "10.00")]
        public float Rating { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        [MaxLength(700)]
        public string Description { get; set; } = null!;
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Screenwriter { get; set; } = null!;

        [InverseProperty(nameof(Cast.Play))]
        public virtual ICollection<Cast> Casts { get; set; }
        [InverseProperty(nameof(Ticket.Play))]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
