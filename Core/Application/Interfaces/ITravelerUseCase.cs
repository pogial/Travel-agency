using Microsoft.AspNetCore.Mvc;
using PruebaBackend.API.DTOs;

namespace PruebaBackend.Core.Application.Interfaces
{
    public interface ITravelerUseCase
    {
        public Task<IActionResult> SaveTraveler(TravelerInserDto travelerInserDto);
    }
}
