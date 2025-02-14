using Microsoft.AspNetCore.Mvc;
using PruebaBackend.API.DTOs;
using PruebaBackend.Core.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace PruebaBackend.API.Controllers
{
    [Route("api/[Controller]")]
    public class TravelerController: ControllerBase
    {
        private ITravelerUseCase _travelerUseCase;
        public TravelerController(ITravelerUseCase travelerUseCase)
        {
            _travelerUseCase = travelerUseCase;
        }

        // <summary>
        /// Crea un Hotel.
        /// </summary>
        /// <remarks>
        /// Se debe enviar la información en el formato JSON especificado.
        /// </remarks>
        /// <param name="hotelInsertDto">Datos de un hotel.</param>
        /// <response code="201">Hotel creado correctamente.</response>
        /// <response code="400">Datos inválidos.</response>
        /// <response code="500">Excepciones.</response>
        [HttpPost("save-traveler")]
        [SwaggerOperation(Summary = "Crea un Viajero", Description = "Crea un Viajero en la Base de Datos")]
        [SwaggerResponse(201, "Viajero creado correctamente.")]
        [SwaggerResponse(400, "Datos inválidos.")]
        [SwaggerResponse(500, "Excepciones.")]
        public async Task<IActionResult> SaveTraveler([FromBody] TravelerInserDto travelerInserDto)
        {
            return await _travelerUseCase.SaveTraveler(travelerInserDto);
        }
    }
}
