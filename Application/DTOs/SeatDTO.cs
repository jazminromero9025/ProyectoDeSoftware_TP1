using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class SeatDTO
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Status { get; set; } // Lo enviamos como string para facilitar la UI [cite: 34, 160]



    }
}
