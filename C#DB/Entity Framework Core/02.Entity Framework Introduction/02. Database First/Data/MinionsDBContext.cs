using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SoftUni.Models;

namespace SoftUni.Data
{
    public partial class MinionsDBContext : DbContext
    {
        public MinionsDBContext()
        {
        }

        public MinionsDBContext(DbContextOptions<MinionsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<EvilnessFactor> EvilnessFactors { get; set; } = null!;
        public virtual DbSet<Minion> Minions { get; set; } = null!;
        public virtual DbSet<Town> Towns { get; set; } = null!;
        public virtual DbSet<Villain> Villains { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-AJ5FISA\\SQLEXPRESS;Database=MinionsDB;Integrated Security = True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EvilnessFactor>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Minion>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Town)
                    .WithMany(p => p.Minions)
                    .HasForeignKey(d => d.TownId)
                    .HasConstraintName("FK__Minions__TownId__4E88ABD4");

                entity.HasMany(d => d.Villains)
                    .WithMany(p => p.Minions)
                    .UsingEntity<Dictionary<string, object>>(
                        "MinionsVillain",
                        l => l.HasOne<Villain>().WithMany().HasForeignKey("VillainId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__MinionsVi__Villa__571DF1D5"),
                        r => r.HasOne<Minion>().WithMany().HasForeignKey("MinionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__MinionsVi__Minio__5629CD9C"),
                        j =>
                        {
                            j.HasKey("MinionId", "VillainId");

                            j.ToTable("MinionsVillains");
                        });
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Towns)
                    .HasForeignKey(d => d.CountryCode)
                    .HasConstraintName("FK__Towns__CountryCo__4BAC3F29");
            });

            modelBuilder.Entity<Villain>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.EvilnessFactor)
                    .WithMany(p => p.Villains)
                    .HasForeignKey(d => d.EvilnessFactorId)
                    .HasConstraintName("FK__Villains__Evilne__534D60F1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
