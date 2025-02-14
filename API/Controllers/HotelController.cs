using Microsoft.AspNetCore.Mvc;
using PruebaBackend.API.DTOs;
using PruebaBackend.Core.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace PruebaBackend.API.Controllers
{
    [Route("api/[Controller]")]
    public class HotelController: ControllerBase
    {
        private IHotelUseCase _hotelUseCase;
        public HotelController(IHotelUseCase hotelUseCase)
        {
            _hotelUseCase = hotelUseCase;
        }

        /// <summary>
        /// Crea un Hotel.
        /// </summary>
        /// <remarks>
        /// Se debe enviar la información en el formato JSON especificado.
        /// </remarks>
        /// <param name="hotelInsertDto">Datos de un hotel.</param>
        /// <response code="201">Hotel creado correctamente.</response>
        /// <response code="400">Datos inválidos.</response>
        /// <response code="500">Excepciones.</response>
        [HttpPost("save-hotel")]
        [SwaggerOperation(Summary = "Crea un Hotel", Description = "Crea un Hotel en la Base de Datos")]
        [SwaggerResponse(201, "Hotel creado correctamente.")]
        [SwaggerResponse(400, "Datos inválidos.")]
        [SwaggerResponse(500, "Excepciones.")]
        public async Task<IActionResult> SaveHotel([FromBody] HotelInsertDto hotelInsertDto)
        {
            return await _hotelUseCase.SaveHotel(hotelInsertDto);
        }

        /// <summary>
        /// Actualiza los datos de un hotel.
        /// </summary>
        /// <remarks>
        /// Se debe enviar la información en el formato JSON especificado.
        /// </remarks>
        /// <param name="hotelUpdateDto">Datos de un hotel.</param>
        /// <response code="201">Hotel actualizado correctamente.</response>
        /// <response code="400">Datos inválidos.</response>
        /// <response code="404">Hotel no encontrado.</response>
        /// <response code="500">Excepciones.</response>
        [HttpPut("update-hotel/{id}")]
        [SwaggerOperation(Summary = "Actualiza hotel", Description = "Actualiza los datos de un hotel")]
        [SwaggerResponse(201, "Hotel actualizado correctamente.")]
        [SwaggerResponse(400, "Datos inválidos.")]
        [SwaggerResponse(404, "Hotel no encontrado.")]
        [SwaggerResponse(500, "Excepciones.")]
        public async Task<IActionResult> UpdateHotel(Guid id, [FromBody] HotelUpdateDto hotelUpdateDto)
        {
            return await _hotelUseCase.UpdateHotel(id, hotelUpdateDto);
        }

        /// <summary>
        /// Actualiza los datos de un hotel.
        /// </summary>
        /// <remarks>
        /// Se debe enviar la información en el formato JSON especificado.
        /// </remarks>
        /// <param name="hotelUpdateStatusDto">Datos del estado del  hotel.</param>
        /// <response code="201">Estado actualizado correctamente.</response>
        /// <response code="400">Datos inválidos.</response>
        /// <response code="404">Hotel no encontrado.</response>
        /// <response code="500">Excepciones.</response>
        [HttpPut("update-status-hotel/{id}")]
        [SwaggerOperation(Summary = "Actualiza estado", Description = "Actualiza el estado de un hotel")]
        [SwaggerResponse(201, "Estado actualizado correctamente.")]
        [SwaggerResponse(400, "Datos inválidos.")]
        [SwaggerResponse(404, "Hotel no encontrado.")]
        [SwaggerResponse(500, "Excepciones.")]
        public async Task<IActionResult> UpdateStatusHotel(Guid id, [FromBody] HotelUpdateStatusDto hotelUpdateStatusDto)
        {
            return await _hotelUseCase.UpdateStatusHotel(id, hotelUpdateStatusDto);
        }
    }
}