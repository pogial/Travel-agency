using Microsoft.AspNetCore.Mvc;
using PruebaBackend.API.DTOs;
using PruebaBackend.Core.Application.Interfaces;
using PruebaBackend.Core.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace PruebaBackend.API.Controllers
{
    [Route("api/[Controller]")]
    public class AgencyController: ControllerBase
    {
        private IAgencyUseCase _agencyUseCase;
        public AgencyController(IAgencyUseCase agencyUseCases)
        {
            _agencyUseCase = agencyUseCases;
        }

        /// <summary>
        /// Crea una agencia.
        /// </summary>
        /// <remarks>
        /// Se debe enviar la información en el formato JSON especificado.
        /// </remarks>
        /// <param name="agencyInsertDto">Datos de un hotel.</param>
        /// <response code="201">Agencia creada correctamente.</response>
        /// <response code="400">Datos inválidos.</response>
        /// <response code="500">Excepciones.</response>
        [HttpPost("save-agency")]
        [SwaggerOperation(Summary = "Crea una Agencia", Description = "Crea una Agencia en la Base de Datos")]
        [SwaggerResponse(201, "Agencia creada correctamente.")]
        [SwaggerResponse(400, "Datos inválidos.")]
        [SwaggerResponse(500, "Excepciones.")]
        public async Task<IActionResult> SaveAgency([FromBody] AgencyInsertDto agencyInsertDto)
        {
            return await _agencyUseCase.SaveAgency(agencyInsertDto);
        }
    }
}