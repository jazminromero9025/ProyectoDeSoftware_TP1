using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event
    {
      
            public Guid Id { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }

            // Relaciones
            public List<Sector> Sectors { get; set; } = new();
        }

}
