using Microsoft.AspNetCore.Mvc;
using PruebaBackend.API.DTOs;
using PruebaBackend.Core.Application.Interfaces;
using PruebaBackend.Core.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace PruebaBackend.API.Controllers
{
    [Route("api/[Controller]")]
    public class PreferredHotelController: ControllerBase
    {
        private IPreferredHotelUseCase _preferredHotelUseCase;
        public PreferredHotelController(IPreferredHotelUseCase preferredHotelService)
        {
            _preferredHotelUseCase = preferredHotelService;
        }

        /// <summary>
        /// Agregar un Hotel en mi lista de hoteles preferidos.
        /// </summary>
        /// <remarks>
        /// Se debe enviar la información en el formato JSON especificado.
        /// </remarks>
        /// <param name="preferredHotelInsertDto">Datos de la agencia con su hotel de preferencia.</param>
        /// <response code="201">Hotel agregado correctamente.</response>
        /// <response code="400">Datos inválidos.</response>
        /// <response code="500">Excepciones.</response>
        [HttpPost("save-preferredHotel")]
        [SwaggerOperation(Summary = "Agrega un Hotel", Description = "Agrega un Hotel a la lista de preferencia de la agencia")]
        [SwaggerResponse(201, "Hotel agregado correctamente.")]
        [SwaggerResponse(400, "Datos inválidos.")]
        [SwaggerResponse(500, "Excepciones.")]
        public async Task<IActionResult> SavePreferredHotel([FromBody] PreferredHotelInsertDto preferredHotelInsertDto)
        {
            return await _preferredHotelUseCase.SavePreferredHotel(preferredHotelInsertDto);
        }
    }
}