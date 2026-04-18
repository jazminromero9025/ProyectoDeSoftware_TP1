
using Application.DTOs;
using Application.Interfaces;
using Application.UseCases.Seats.Queries;

namespace Application.Services
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _seatRepository;

        // se inyecta el repository
        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<List<SeatDTO>> GetSeatsBySectorAsync(GetSeatsBySectorQuery query )
        {
            // El service delega la búsqueda al repositorio usando el query
            var seats = await _seatRepository.GetBySectorIdAsync(query);

            // Mapeo de entidad a DTO
            return seats.Select(s => new SeatDTO
            {
                Id = s.Id,
                Number = s.Number,
                Status = s.Status.ToString()
            }).ToList();
        }
    }
}