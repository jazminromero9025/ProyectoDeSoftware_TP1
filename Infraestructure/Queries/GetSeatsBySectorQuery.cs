using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.DTOs;
using Infraestructure.Data;
using Domain.Entities;

namespace Infraestructure.Queries
{
    public class GetSeatsBySectorQuery
    {
        
        
            private readonly AppDbContext _context;

            public GetSeatsBySectorQuery(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<SeatDTO>> ExecuteAsync(Guid sectorId)
            {
            //aca es donde ocurre la consulta a la base de datos
            return await _context.Seats
                    .Where(s => s.SectorId == sectorId)
                    .Select(s => new SeatDTO
                    {
                        Id = s.Id,
                        Number = s.Number,
                        
                        Status = s.Status.ToString() // Mapeo de Enum a String
                    })
                    .AsNoTracking() // Mejora el rendimiento porque es una lectura
                    .ToListAsync();
            }
        }

    
}
