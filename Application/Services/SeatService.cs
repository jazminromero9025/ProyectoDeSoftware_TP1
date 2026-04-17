using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    
        public class SeatService : ISeatService
        {
            private readonly ISeatRepository _repository;

            public SeatService(ISeatRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<SeatDTO>> GetMapBySector(Guid sectorId)
            {
                return await _repository.GetSeatsBySectorAsync(sectorId);
            //"Si el usuario no está logueado, ocultar los asientos VIP". Esa lógica iría acá.
        }
    }
    
}
