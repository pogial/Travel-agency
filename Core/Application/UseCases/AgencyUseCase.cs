using Microsoft.AspNetCore.Mvc;
using PruebaBackend.API.DTOs;
using PruebaBackend.Core.Application.Interfaces;
using PruebaBackend.Core.Domain.Constants;
using PruebaBackend.Core.Domain.Entities;
using PruebaBackend.Core.Domain.Interfaces;

namespace PruebaBackend.Core.Application.UseCases
{
    public class AgencyUseCase: IAgencyUseCase
    {
        private readonly ILogger<AgencyUseCase> _logger;
        private IAgencyRepository _agencyRepository;

        public AgencyUseCase(IAgencyRepository agencyRepository, ILogger<AgencyUseCase> logger)
        {
            _agencyRepository = agencyRepository;
            _logger = logger;
        }
        public async Task<IActionResult> SaveAgency(AgencyInsertDto agencyInsertDto)
        {
            try
            {
                if(agencyInsertDto == null)
                {
                    return new BadRequestObjectResult(Constants.Messages.NotValidAgency);
                }

                Agency agency = new Agency(agencyInsertDto.name, agencyInsertDto.address, agencyInsertDto.email, agencyInsertDto.phone);
                await _agencyRepository.SaveAgency(agency);
                return new CreatedResult($"api/Agency/{agency.agencyId}", agency);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, Constants.Messages.ErrorSaveAgency);
                return new ObjectResult(Constants.Messages.InternalErrorSavAgency) { StatusCode = 500 };
            }
        }
    }
}