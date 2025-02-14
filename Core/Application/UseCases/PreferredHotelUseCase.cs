using Microsoft.AspNetCore.Mvc;
using PruebaBackend.API.DTOs;
using PruebaBackend.Core.Application.Interfaces;
using PruebaBackend.Core.Domain.Constants;
using PruebaBackend.Core.Domain.Entities;
using PruebaBackend.Core.Domain.Interfaces;

namespace PruebaBackend.Core.Application.UseCases
{
    public class PreferredHotelUseCase: IPreferredHotelUseCase
    {
        private readonly IPreferredHotelRepository _preferredHotelRepository;
        private readonly ILogger<PreferredHotelUseCase> _logger;
        public PreferredHotelUseCase(IPreferredHotelRepository preferredHotelRepository, ILogger<PreferredHotelUseCase> logger)
        {
            _preferredHotelRepository = preferredHotelRepository;
            _logger = logger;
        }

        public async Task<IActionResult> SavePreferredHotel(PreferredHotelInsertDto preferredHotelInsertDto)
        {
            try
            {
                if(preferredHotelInsertDto == null)
                {
                    return new BadRequestObjectResult(Constants.Messages.NotValidPreferHotel);
                }

                PreferredHotel preferredHotel = new PreferredHotel(preferredHotelInsertDto.agencyId, preferredHotelInsertDto.hotelId);
                await _preferredHotelRepository.SavePreferredHotel(preferredHotel);
                return new CreatedResult($"api/PreferredHotel/{preferredHotel}", preferredHotel);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, Constants.Messages.ErrorSavePreferHotel);
                return new ObjectResult(Constants.Messages.InternalErrorSavPreferHotel) { StatusCode = 500 };
            }
        }
    }
}
