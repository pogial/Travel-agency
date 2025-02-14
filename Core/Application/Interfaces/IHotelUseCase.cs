using Microsoft.AspNetCore.Mvc;
using PruebaBackend.API.DTOs;
using PruebaBackend.Core.Domain.Entities;

namespace PruebaBackend.Core.Application.Interfaces
{
    public interface IHotelUseCase
    {
        public Task<IActionResult> SaveHotel(HotelInsertDto hotelInsertDto);
        public Task<IActionResult> UpdateHotel(Guid id, HotelUpdateDto hotelUpdateDto);
        public Task<IActionResult> UpdateStatusHotel(Guid id, HotelUpdateStatusDto hotelUpdateStatusDto);
    }
}
