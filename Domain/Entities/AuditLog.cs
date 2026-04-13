using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AuditLog
    {
       
            public Guid Id { get; set; }

            public string Action { get; set; } // "RESERVE", "PURCHASE", etc.

            public Guid SeatId { get; set; }
            public DateTime Date { get; set; }

            public string Description { get; set; }
        }
}
