using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Reservation
    {
            public Guid Id { get; set; }

            public Guid SeatId { get; set; }
            public Seat Seat { get; set; }

            public Guid UserId { get; set; }
            public User User { get; set; }

            public DateTime CreatedAt { get; set; }

            public ReservationStatus Status { get; set; }
        }
}
