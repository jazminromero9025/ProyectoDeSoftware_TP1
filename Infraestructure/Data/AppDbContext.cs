using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
       


            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
            {
            }

            // 🔹 Tablas
            public DbSet<Event> Events { get; set; }
            public DbSet<Sector> Sectors { get; set; }
            public DbSet<Seat> Seats { get; set; }
            public DbSet<Reservation> Reservations { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<AuditLog> AuditLogs { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // 🔹 Relaciones

                // Event → Sectors
                modelBuilder.Entity<Event>()
                    .HasMany(e => e.Sectors)
                    .WithOne(s => s.Event)
                    .HasForeignKey(s => s.EventId);

                // Sector → Seats
                modelBuilder.Entity<Sector>()
                    .HasMany(s => s.Seats)
                    .WithOne(se => se.Sector)
                    .HasForeignKey(se => se.SectorId);

                // Seat → Reservation
                modelBuilder.Entity<Reservation>()
                    .HasOne(r => r.Seat)
                    .WithMany()
                    .HasForeignKey(r => r.SeatId);

                // User → Reservations
                modelBuilder.Entity<Reservation>()
                    .HasOne(r => r.User)
                    .WithMany(u => u.Reservations)
                    .HasForeignKey(r => r.UserId);

                // 🔥 CONCURRENCIA (MUY IMPORTANTE)
                modelBuilder.Entity<Seat>()
                    .Property(s => s.RowVersion)
                    .IsRowVersion();
            }
        }
    }
