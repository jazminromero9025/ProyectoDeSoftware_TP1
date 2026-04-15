using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Infraestructure.Data
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // Evitar re-seedear si ya hay datos
            if (context.Events.Any()) return;

            //USUARIOS DE PRUEBA ──────────────────────────────────────
            var users = new List<User>
            {
                new User { Id = Guid.NewGuid(), Name = "Juan Pérez" },
                new User { Id = Guid.NewGuid(), Name = "María García" },
                new User { Id = Guid.NewGuid(), Name = "Carlos López" },
            };
            context.Users.AddRange(users);

            //EVENTO ──────────────────────────────────────────────────
            var evento = new Event
            {
                Id = Guid.NewGuid(),
                Name = "Concierto de Rock",
                Date = DateTime.UtcNow.AddDays(30),
                Sectors = new List<Sector>()
            };

            //SECTORES Y BUTACAS ──────────────────────────────────────
            var sectorNames = new[] { "Sector A", "Sector B" };

            foreach (var sectorName in sectorNames)
            {
                var sector = new Sector
                {
                    Id = Guid.NewGuid(),
                    Name = sectorName,
                    EventId = evento.Id,
                    Seats = new List<Seat>()
                };

                for (int i = 1; i <= 50; i++)
                {
                    sector.Seats.Add(new Seat
                    {
                        Id = Guid.NewGuid(),
                        Number = i,
                        SectorId = sector.Id,
                        Status = SeatStatus.Available
                    });
                }

                evento.Sectors.Add(sector);
            }

            context.Events.Add(evento);
            context.SaveChanges();
        }
    }
}
