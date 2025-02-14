using Microsoft.AspNetCore.Mvc;
using PruebaBackend.API.DTOs;
using PruebaBackend.Core.Application.Interfaces;
using PruebaBackend.Core.Domain.Constants;
using PruebaBackend.Core.Domain.Entities;
using PruebaBackend.Core.Domain.Interfaces;

namespace PruebaBackend.Core.Application.UseCases
{
    public class RoomUseCase: IRoomUseCase
    {
        private readonly IRoomRepository _roomRepository;
        private readonly ILogger<RoomUseCase> _logger;
        public RoomUseCase(IRoomRepository roomRepository, ILogger<RoomUseCase> logger)
        {
            _roomRepository = roomRepository;
            _logger = logger;
        }
        public async Task<IActionResult> SaveRoom(RoomInsertDto roomInsertDto)
        {
            try
            {
                if(roomInsertDto == null)
                {
                    return new BadRequestObjectResult(Constants.Messages.NotValidRoom);
                }

                Room room = new Room(roomInsertDto.hotelId, roomInsertDto.roomNumber, roomInsertDto.roomType, roomInsertDto.capacityPersons,
                                     roomInsertDto.baseCost, roomInsertDto.taxesPercentage, roomInsertDto.price, roomInsertDto.location, Constants.Status.Available);

                await _roomRepository.SaveRoom(room);
                return new CreatedResult($"api/Room/{room.roomId}", room);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, Constants.Messages.ErrorSaveRoom);
                return new ObjectResult(Constants.Messages.InternalErrorSavRoom) { StatusCode = 500 };
            }
        }
        public async Task<IActionResult> UpdateRoom(Guid id, RoomUpdateDto roomUpdateDto)
        {
            try
            {
                if(roomUpdateDto == null)
                {
                    return new BadRequestObjectResult(Constants.Messages.NotValidRoom);
                }

                var existingRoom = await _roomRepository.FindById(id);

                if(existingRoom == null)
                {
                    return new NotFoundObjectResult(Constants.Messages.NotExistsRoom);
                };

                existingRoom.UpdateRoom(roomUpdateDto.roomType, roomUpdateDto.capacityPersons, roomUpdateDto.baseCost, roomUpdateDto.taxesPercentage,
                                        roomUpdateDto.price);

                await _roomRepository.UpdateRoom(existingRoom);

                return new CreatedResult($"api/Room/{existingRoom.roomId}", existingRoom);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, Constants.Messages.ErrorUpdateRoom);
                return new ObjectResult(Constants.Messages.InternalErrorUpdRoom) { StatusCode = 500 };
            }
        }
        public async Task<IActionResult> UpdateStatusRoom(Guid id, RoomUpdateStatusDto roomUpdateStatusDto)
        {
            try
            {
                if(roomUpdateStatusDto == null || roomUpdateStatusDto.status != 0 || roomUpdateStatusDto.status != 1)
                {
                    return new BadRequestObjectResult(Constants.Messages.NotValidStatusHotel);
                }

                var existingRoom = await _roomRepository.FindById(id);

                if(existingRoom == null)
                {
                    return new NotFoundObjectResult(Constants.Messages.NotExistsHotel);
                };

                if(roomUpdateStatusDto.status == 0)
                {
                    existingRoom.UpdateStatusRoom(Constants.Status.Unavailable);
                }
                else
                {
                    existingRoom.UpdateStatusRoom(Constants.Status.Available);
                }

                await _roomRepository.UpdateRoom(existingRoom);

                return new CreatedResult($"api/Room/{existingRoom.roomId}", existingRoom);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, Constants.Messages.ErrorUpdateStatusHotel);
                return new ObjectResult(Constants.Messages.InternalErrorUpdStatusHotel) { StatusCode = 500 };
            }
        }
    }
}