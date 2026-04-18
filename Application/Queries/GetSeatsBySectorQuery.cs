
using System;

namespace Application.Queries
{
    public class GetSeatsBySectorQuery
    {
        public Guid SectorId { get; set; }

        public GetSeatsBySectorQuery(Guid sectorId)
        {
            SectorId = sectorId;
        }
    }
}
