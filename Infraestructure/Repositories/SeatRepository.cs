using Application.DTOs;
using Infraestructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;



namespace Infraestructure.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly GetSeatsBySectorQuery _query;

        public SeatRepository(GetSeatsBySectorQuery query)
        {
            _query = query;
        }

        public async Task<IEnumerable<SeatDTO>> GetSeatsBySectorAsync(Guid sectorId)
        {
            // El repositorio delega la búsqueda a la clase Query
            return await _query.ExecuteAsync(sectorId);
        }


    }
}
