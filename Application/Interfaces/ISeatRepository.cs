using Application.UseCases.Seats.Queries;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetBySectorIdAsync(GetSeatsBySectorQuery query);
    }
}