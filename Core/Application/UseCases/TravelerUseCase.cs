using Microsoft.AspNetCore.Mvc;
using PruebaBackend.API.DTOs;
using PruebaBackend.Core.Application.Interfaces;
using PruebaBackend.Core.Domain.Constants;
using PruebaBackend.Core.Domain.Entities;
using PruebaBackend.Core.Domain.Interfaces;
using PruebaBackend.Infrastructure.Persistence;
using PruebaBackend.Infrastructure.Repositories;

namespace PruebaBackend.Core.Application.UseCases
{
    public class TravelerUseCase: ITravelerUseCase
    {
        private readonly ITravelerRepository _travelerRepository;
        private readonly ILogger<TravelerUseCase> _logger;
        public TravelerUseCase(ITravelerRepository travelerRepository, ILogger<TravelerUseCase> logger)
        {
            _travelerRepository = travelerRepository;
            _logger = logger;
        }

        public async Task<IActionResult> SaveTraveler(TravelerInserDto travelerInserDto)
        {
            try
            {
                if(travelerInserDto == null)
                {
                    return new BadRequestObjectResult(Constants.Messages.NotValidTraveler);
                }

                Traveler treveler = new Traveler(travelerInserDto.firstName, travelerInserDto.lastName, travelerInserDto.dateOfBirth,
                                                 travelerInserDto.gender, travelerInserDto.documentType, travelerInserDto.documentNumber,
                                                 travelerInserDto.email, travelerInserDto.phoneNumber);

                await _travelerRepository.SaveTraveler(treveler);
                return new CreatedResult($"api/Agency/{treveler.travelerId}", treveler);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, Constants.Messages.ErrorSaveTravel);
                return new ObjectResult(Constants.Messages.InternalErrorSavTravel) { StatusCode = 500 };
            }
        }
    }
}
