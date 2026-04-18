
using Application.DTOs;
using Application.Interfaces;
using Application.Queries;

namespace Application.Services
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _seatRepository;

        // DI: se inyecta el repository (NO new)
        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<List<SeatDTO>> GetSeatsBySectorAsync(Guid sectorId)
        {
            // 🔥 El Service crea el Query (clave en tu flujo)
            var query = new GetSeatsBySectorQuery(sectorId);

            // Se lo pasa al repository
            var seats = await _seatRepository.GetBySectorIdAsync(query);

            // Mapeo a DTO
            return seats.Select(s => new SeatDTO
            {
                Id = s.Id,
                Number = s.Number,
                Status = s.Status.ToString()
            }).ToList();
        }
    }
}