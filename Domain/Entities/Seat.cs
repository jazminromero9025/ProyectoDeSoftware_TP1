using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Seat
    {
            public Guid Id { get; set; }
            public int Number { get; set; }

            public Guid SectorId { get; set; }
            public Sector Sector { get; set; }

            public SeatStatus Status { get; set; }

            // CONCURRENCIA
            public byte[] RowVersion { get; set; }
        }
}
