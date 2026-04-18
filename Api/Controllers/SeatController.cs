using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
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
            var result = await _seatService.GetSeatsBySectorAsync(sectorId);

            return Ok(result);
        }
    }
}