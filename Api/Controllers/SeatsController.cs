using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    // La URL debe ser plural y jerárquica: api/v1/sectors/{id}/seats 
    [Route("api/v1/sectors")]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService _service;

        // Inyección de dependencias: Le pedimos el servicio a la capa de Application
        public SeatsController(ISeatService service)
        {
            _service = service;
        }

        // Endpoint para listar asientos por sector
        [HttpGet("{sectorId}/seats")]
        public async Task<IActionResult> GetSeats(Guid sectorId)
        {
            // El controller solo "pasa la pelota" al Service
            var seats = await _service.GetMapBySector(sectorId);

            // Si no hay asientos, devolvemos 404 [cite: 65]
            if (seats == null) return NotFound();

            // Si todo está bien, devolvemos 200 OK con la lista [cite: 65]
            return Ok(seats);
        }
    }




}
