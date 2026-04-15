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
    public class AppDbContext : DbContext //esta clase representa la conexion con la base de datos
    {
       


            public AppDbContext(DbContextOptions<AppDbContext> options) //contrsuctor que recibe la configuracion
                : base(options) //se la pasa a dbcontext (EF usa esto para conectarse a la base de datos
            {
            }

            // Tablas (cada DbSet = una tabla en la base de datos)
             public DbSet<Event> Events { get; set; } // Tabla de eventos
            public DbSet<Sector> Sectors { get; set; } //tabla de sectores
            public DbSet<Seat> Seats { get; set; } //tabla de butacas
            public DbSet<Reservation> Reservations { get; set; } //tabla de reservas
            public DbSet<User> Users { get; set; } // tabla de usuarios
            public DbSet<AuditLog> AuditLogs { get; set; } //tabla de auditoria

            protected override void OnModelCreating(ModelBuilder modelBuilder) // Método donde se configuran relaciones
        {
                base.OnModelCreating(modelBuilder); //llama a la configuracion base 

                // Relaciones

                // Event → Sectors 
                modelBuilder.Entity<Event>() //estoyconfigurando la entidad event 
                    .HasMany(e => e.Sectors) //un evento tiene muchos sectores
                    .WithOne(s => s.Event) //cada sector pertenece a un evento 
                    .HasForeignKey(s => s.EventId); //la FK esta en sector (EventId)

                // Sector → Seats
                modelBuilder.Entity<Sector>() //configura sector
                    .HasMany(s => s.Seats) //un sector tiene muchas seats (butacas)
                    .WithOne(se => se.Sector) //cada seat pertenece a un sector 
                    .HasForeignKey(se => se.SectorId); //FK en Seat (SectorId)

                // Seat → Reservation
                modelBuilder.Entity<Reservation>() // Configuro Reservation
                    .HasOne(r => r.Seat) //una reservation tiene una Seat
                    .WithMany() // Una Seat puede tener MUCHAS Reservations (no guardo la lista en Seat)
                    .HasForeignKey(r => r.SeatId); // FK en Reservation (SeatId)

            // User → Reservations
            modelBuilder.Entity<Reservation>()  // Configuro Reservation otra vez
                    .HasOne(r => r.User) // Una Reservation pertenece a UN User
                    .WithMany(u => u.Reservations) // Un User tiene MUCHAS Reservations
                    .HasForeignKey(r => r.UserId); // FK en Reservation (UserId)

            // CONCURRENCIA (MUY IMPORTANTE)
            modelBuilder.Entity<Seat>()  // Configuro Seat
                    .Property(s => s.RowVersion) // Uso la propiedad RowVersion
                    .IsRowVersion(); // Esto activa control de concurrencia (evita doble compra)

        }
    }
    }
