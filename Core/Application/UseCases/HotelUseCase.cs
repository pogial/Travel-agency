using Microsoft.AspNetCore.Mvc;
using PruebaBackend.API.DTOs;
using PruebaBackend.Core.Application.Interfaces;
using PruebaBackend.Core.Domain.Constants;
using PruebaBackend.Core.Domain.Entities;
using PruebaBackend.Core.Domain.Interfaces;

namespace PruebaBackend.Core.Application.UseCases
{
    public class HotelUseCase: IHotelUseCase
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly ILogger<HotelUseCase> _logger;
        public HotelUseCase(IHotelRepository hotelRepository, ILogger<HotelUseCase> logger)
        {
            _hotelRepository = hotelRepository;
            _logger = logger;
        }

        public async Task<IActionResult> SaveHotel(HotelInsertDto hotelInsertDto)
        {
            try
            {
                if(hotelInsertDto == null)
                {
                    return new BadRequestObjectResult(Constants.Messages.NotValidHotel);
                }

                Hotel hotel = new Hotel(hotelInsertDto.identificationNumber, hotelInsertDto.name, hotelInsertDto.location, hotelInsertDto.address, hotelInsertDto.capacityPersons, hotelInsertDto.description, Constants.Status.Enabled);

                await _hotelRepository.SaveHotel(hotel);
                return new CreatedResult($"api/Hotel/{hotel.hotelId}", hotel);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, Constants.Messages.ErrorSaveHotel);
                return new ObjectResult(Constants.Messages.InternalErrorSavHotel) { StatusCode = 500 };
            }
        }
        public async Task<IActionResult> UpdateHotel(Guid id, HotelUpdateDto hotelUpdateDto)
        {
            try
            {
                if(hotelUpdateDto == null)
                {
                    return new BadRequestObjectResult(Constants.Messages.NotValidHotel);
                }

                var existingHotel = await _hotelRepository.FindById(id);

                if(existingHotel == null)
                {
                    return new NotFoundObjectResult(Constants.Messages.NotExistsHotel);
                };

                existingHotel.UpdateHotel(hotelUpdateDto.identificationNumber, hotelUpdateDto.name, hotelUpdateDto.location, hotelUpdateDto.address,
                                          hotelUpdateDto.capacityPersons, hotelUpdateDto.description);

                await _hotelRepository.UpdateHotel(existingHotel);

                return new CreatedResult($"api/Hotel/{existingHotel.hotelId}", existingHotel);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, Constants.Messages.ErrorUpdateHotel);
                return new ObjectResult(Constants.Messages.InternalErrorUpdHotel) { StatusCode = 500 };
            }
        }
        public async Task<IActionResult> UpdateStatusHotel(Guid id, HotelUpdateStatusDto hotelUpdateStatusDto)
        {
            try
            {
                if(hotelUpdateStatusDto == null || (hotelUpdateStatusDto.status > 1 || hotelUpdateStatusDto.status < 0))
                {
                    return new BadRequestObjectResult(Constants.Messages.NotValidStatusHotel);
                }

                var existingHotel = await _hotelRepository.FindById(id);

                if(existingHotel == null)
                {
                    return new NotFoundObjectResult(Constants.Messages.NotExistsHotel);
                };

                if(hotelUpdateStatusDto.status == 0)
                {
                    existingHotel.UpdateStatusHotel(Constants.Status.Disabled);
                }
                else
                {
                    existingHotel.UpdateStatusHotel(Constants.Status.Enabled);
                }

                await _hotelRepository.UpdateHotel(existingHotel);

                return new CreatedResult($"api/Hotel/{existingHotel.hotelId}", existingHotel);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, Constants.Messages.ErrorUpdateStatusHotel);
                return new ObjectResult(Constants.Messages.InternalErrorUpdStatusHotel) { StatusCode = 500 };
            }
        }
    }
}