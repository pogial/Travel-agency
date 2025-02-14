using Microsoft.AspNetCore.Mvc;
using PruebaBackend.API.DTOs;

namespace PruebaBackend.Core.Application.Interfaces
{
    public interface IRoomUseCase
    {
        public Task<IActionResult> SaveRoom(RoomInsertDto roomInsertDto);
        public Task<IActionResult> UpdateRoom(Guid id, RoomUpdateDto roomUpdateDto);
        public Task<IActionResult> UpdateStatusRoom(Guid id, RoomUpdateStatusDto roomUpdateStatusDto);
    }
}
