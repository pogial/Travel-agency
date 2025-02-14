using Microsoft.AspNetCore.Mvc;
using PruebaBackend.API.DTOs;
using PruebaBackend.Core.Domain.Entities;

namespace PruebaBackend.Core.Application.Interfaces
{
    public interface IReservationUseCase
    {
        public Task<IActionResult> SaveReservation(ReservationInsertDto reservationInsertDto);
        public Task<IActionResult> GetReservationById(Guid id);
    }
}
