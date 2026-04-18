using Application.Interfaces;
using Application.UseCases.Seats.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/sectors/{sectorId}/seats")]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService _seatService;

        // se inyecta el service
        public SeatsController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet("sector/{sectorId}")]
        public async Task<IActionResult> GetBySector(Guid sectorId)
        {


            if (sectorId == Guid.Empty)
                return BadRequest("ID inválido");



            // Aquí "empaquetamos" el dato en el Query
            var query = new GetSeatsBySectorQuery(sectorId);
            var result = await _seatService.GetSeatsBySectorAsync(query);

            return Ok(result);
        }
    }
}