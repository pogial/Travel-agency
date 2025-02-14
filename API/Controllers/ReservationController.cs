using Microsoft.AspNetCore.Mvc;
using PruebaBackend.API.DTOs;
using PruebaBackend.Core.Application.Interfaces;
using PruebaBackend.Core.Domain.Entities;

namespace PruebaBackend.API.Controllers
{
    [Route("api/[Controller]")]
    public class ReservationController: ControllerBase
    {
        private IReservationUseCase _reservationUseCase;
        public ReservationController(IReservationUseCase reservationUseCase)
        {
            _reservationUseCase = reservationUseCase;
        }

        [HttpPost("save-reservation")]
        public async Task<IActionResult> SaveReservation([FromBody] ReservationInsertDto reservationInsertDto)
        {
            return await _reservationUseCase.SaveReservation(reservationInsertDto);
        }

        [HttpGet("reservation/{id}")]
        public async Task<IActionResult> GetReservationById(Guid id)
        {
            return await _reservationUseCase.GetReservationById(id);
        }
    }
}
