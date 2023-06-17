using Homies.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Homies.Data
{
    public class HomiesDbContext : IdentityDbContext
    {
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Homies.Data.Models.Type>()
                .HasData(new Homies.Data.Models.Type()
                {
                    Id = 1,
                    Name = "Animals"
                },
                new Homies.Data.Models.Type()
                {
                    Id = 2,
                    Name = "Fun"
                },
                new Homies.Data.Models.Type()
                {
                    Id = 3,
                    Name = "Discussion"
                },
                new Homies.Data.Models.Type()
                {
                    Id = 4,
                    Name = "Work"
                });

            modelBuilder.Entity<EventParticipant>(e =>
            {
                e.HasKey(ep => new { ep.HelperId, ep.EventId });
            });

            modelBuilder.Entity<EventParticipant>()
                .HasOne(t => t.Event)
                .WithMany(c => c.EventsParticipants)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<EventParticipant> EventParticipants { get; set; } = null!;
        public DbSet<Homies.Data.Models.Type> Types { get; set; } = null!;
    }
}