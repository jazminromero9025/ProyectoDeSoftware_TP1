
using Application.Interfaces;
using Application.UseCases.Seats.Queries;
using Domain.Entities;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly AppDbContext _context;

        public SeatRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Seat>> GetBySectorIdAsync(GetSeatsBySectorQuery query)
        {
            return await _context.Seats
                .Where(s => s.SectorId == query.SectorId)
                .ToListAsync();
        }
    }
}