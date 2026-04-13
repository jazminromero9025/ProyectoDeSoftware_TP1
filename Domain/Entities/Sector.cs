using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sector
    {
            public Guid Id { get; set; }
            public string Name { get; set; }

            public Guid EventId { get; set; }
            public Event Event { get; set; }

            // Relaciones
            public List<Seat> Seats { get; set; } = new();
        }

    
}
