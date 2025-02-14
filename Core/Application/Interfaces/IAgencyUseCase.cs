using Microsoft.AspNetCore.Mvc;
using PruebaBackend.API.DTOs;

namespace PruebaBackend.Core.Application.Interfaces
{
    public interface IAgencyUseCase
    {
        public Task<IActionResult> SaveAgency(AgencyInsertDto agencyInsertDto);
    }
}
