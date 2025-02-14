using Microsoft.AspNetCore.Mvc;
using PruebaBackend.API.DTOs;
using PruebaBackend.Core.Application.Interfaces;
using PruebaBackend.Core.Application.UseCases;
using Swashbuckle.AspNetCore.Annotations;

namespace PruebaBackend.API.Controllers
{
    [Route("api/[Controller]")]
    public class RoomController: ControllerBase
    {
        private IRoomUseCase _roomUseCase;
        public RoomController(IRoomUseCase roomUseCase)
        {
            _roomUseCase = roomUseCase;
        }

        /// <summary>
        /// Asigna habitaciones a un Hotel.
        /// </summary>
        /// <remarks>
        /// Se debe enviar la información en el formato JSON especificado.
        /// </remarks>
        /// <param name="roomInsertDto">Datos de un hotel.</param>
        /// <response code="201">Habitación asignada correctamente.</response>
        /// <response code="400">Datos inválidos.</response>
        /// <response code="500">Excepciones.</response>
        [HttpPost("save-room")]
        [SwaggerOperation(Summary = "Asigna habitación", Description = "Asigna habitación a un Hotel")]
        [SwaggerResponse(201, "Habitación asignada correctamente.")]
        [SwaggerResponse(400, "Datos inválidos.")]
        [SwaggerResponse(500, "Excepciones.")]
        public async Task<IActionResult> SaveRoom([FromBody] RoomInsertDto roomInsertDto)
        {
            return await _roomUseCase.SaveRoom(roomInsertDto);
        }

        /// <summary>
        /// Actualiza los datos de un hotel.
        /// </summary>
        /// <remarks>
        /// Se debe enviar la información en el formato JSON especificado.
        /// </remarks>
        /// <param name="roomUpdateDto">Datos de una habitación.</param>
        /// <response code="201">Habitación actualizada correctamente.</response>
        /// <response code="400">Datos inválidos.</response>
        /// <response code="404">Habitación no encontrada.</response>
        /// <response code="500">Excepciones.</response>
        [HttpPut("update-room/{id}")]
        [SwaggerOperation(Summary = "Actualiza habitación", Description = "Actualiza los datos de una habitación")]
        [SwaggerResponse(201, "Habitación actualizada correctamente.")]
        [SwaggerResponse(400, "Datos inválidos.")]
        [SwaggerResponse(404, "Habitación no encontrada.")]
        [SwaggerResponse(500, "Excepciones.")]
        public async Task<IActionResult> UpdateRoom(Guid id, [FromBody] RoomUpdateDto roomUpdateDto)
        {
            return await _roomUseCase.UpdateRoom(id, roomUpdateDto);
        }

        /// <summary>
        /// Actualiza los datos de un hotel.
        /// </summary>
        /// <remarks>
        /// Se debe enviar la información en el formato JSON especificado.
        /// </remarks>
        /// <param name="roomUpdateStatusDto">Datos del estado de la habitación.</param>
        /// <response code="201">Estado actualizado correctamente.</response>
        /// <response code="400">Datos inválidos.</response>
        /// <response code="404">Hotel no encontrado.</response>
        /// <response code="500">Excepciones.</response>
        [HttpPut("update-status-room/{id}")]
        [SwaggerOperation(Summary = "Actualiza estado", Description = "Actualiza el estado de una habitación")]
        [SwaggerResponse(201, "Estado actualizado correctamente.")]
        [SwaggerResponse(400, "Datos inválidos.")]
        [SwaggerResponse(404, "Hotel no encontrado.")]
        [SwaggerResponse(500, "Excepciones.")]
        public async Task<IActionResult> UpdateStatusRoom(Guid id, [FromBody] RoomUpdateStatusDto roomUpdateStatusDto)
        {
            return await _roomUseCase.UpdateStatusRoom(id, roomUpdateStatusDto);
        }
    }
}
