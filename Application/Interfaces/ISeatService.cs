using Application.DTOs;

namespace Application.Interfaces
{
    public interface ISeatService
    {
        Task<List<SeatDTO>> GetSeatsBySectorAsync(Guid sectorId);
    }
}