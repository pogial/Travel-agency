using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PruebaBackend.API.DTOs;
using PruebaBackend.Core.Application.Interfaces;
using PruebaBackend.Core.Domain.Constants;
using PruebaBackend.Core.Domain.Entities;
using PruebaBackend.Core.Domain.Interfaces;
using PruebaBackend.Infrastructure.Repositories;
using System.Net;
using System.Xml.Linq;
using static PruebaBackend.Core.Domain.Constants.Constants;

namespace PruebaBackend.Core.Application.UseCases
{
    public class ReservationUseCase: IReservationUseCase
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ITravelerRepository _travelerRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IEmergencyContactRepository _emergencyContactRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly ILogger<ReservationUseCase> _logger;
        public ReservationUseCase(IReservationRepository reservationRepository, ITravelerRepository travelerRepository, IHotelRepository hotelRepository, IEmergencyContactRepository emergencyContactRepository,
                                  IGuestRepository guestRepository, ILogger<ReservationUseCase> logger)
        {
            _reservationRepository = reservationRepository;
            _travelerRepository = travelerRepository;
            _hotelRepository = hotelRepository;
            _emergencyContactRepository = emergencyContactRepository;
            _guestRepository = guestRepository; 
            _logger = logger;
        }

        public async Task<IActionResult> SaveReservation(ReservationInsertDto reservationInsertDto)
        {
            try
            {
                if(reservationInsertDto == null)
                {
                    return new BadRequestObjectResult(Constants.Messages.NotValidReservation);
                }

                if(reservationInsertDto.emergencyContact == null)
                {
                    return new BadRequestObjectResult(Constants.Messages.NotValidContactEmergencyReservation);
                }

                if(reservationInsertDto.roomIds == null)
                {
                    return new BadRequestObjectResult(Constants.Messages.NotValidRoom);
                }

                EmergencyContact emergencyContact = new EmergencyContact(reservationInsertDto.emergencyContact.firstName, reservationInsertDto.emergencyContact.lastName, reservationInsertDto.emergencyContact.phoneNumber);
                Reservation reservation = new Reservation(reservationInsertDto.travelerId, reservationInsertDto.hotelId, reservationInsertDto.checkIn, reservationInsertDto.checkOut, emergencyContact.emergencyContactId, Constants.Status.Pending);

                await _emergencyContactRepository.SaveEmergencyContact(emergencyContact);
                await _reservationRepository.SaveReservation(reservation);

                foreach(var guest in reservationInsertDto.guests)
                {
                    Guest guestReservation = new Guest(reservation.reservationId, guest.firstName, guest.lastName, guest.email, guest.phone, guest.dateOfBirth, guest.nationality, guest.gender);
                    await _guestRepository.SaveGuest(guestReservation);
                }

                foreach(var roomId in reservationInsertDto.roomIds)
                {
                    ReservationRoom reservationRoom = new ReservationRoom(reservation.reservationId, roomId);
                    await _reservationRepository.SaveRoomReservation(reservationRoom);
                }

                return new CreatedResult($"api/Reservation/{reservation}", reservation);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, Constants.Messages.ErrorSaveReservation);
                return new ObjectResult(Constants.Messages.InternalErrorSavReservation) { StatusCode = 500 };
            }
        }
        public async Task<IActionResult> GetReservationById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new BadRequestObjectResult("El ID de la reserva no puede estar vacío.");
            }
            
            Reservation? reservation = await _reservationRepository.FindById(id);

            if(reservation == null)
            {
                return new NotFoundObjectResult(Constants.Messages.NotExistsHotel);
            }

            Traveler? travelerReservation = await _travelerRepository.FindById(reservation.travelerId);

            if(travelerReservation == null)
            {
                return new NotFoundObjectResult(Constants.Messages.NotExistsHotel);
            }

            Hotel? hotelReservation = await _hotelRepository.FindById(reservation.hotelId);

            if(hotelReservation == null)
            {
                return new NotFoundObjectResult(Constants.Messages.NotExistsHotel);
            }

            EmergencyContact? emergencyContactReservation = await _emergencyContactRepository.FindById(reservation.emergencyContactId.Value);

            if(emergencyContactReservation == null)
            {
                return new NotFoundObjectResult(Constants.Messages.NotExistsHotel);
            }

            var responseReservation = new
            {
                reservation = new
                {
                    reservationId = reservation.reservationId,
                    checkIn = reservation.checkIn,
                    checkOut = reservation.checkOut,
                    status = reservation.status

                },
                traveler = new
                {
                    travelerId = travelerReservation.travelerId,
                    firstName = travelerReservation.firstName,
                    lastName = travelerReservation.lastName,
                    dateOfBirth = travelerReservation.dateOfBirth,
                    gender = travelerReservation.gender,
                    documentType = travelerReservation.documentType,
                    documentNumber = travelerReservation.documentNumber,
                    email = travelerReservation.email,
                    phoneNumber = travelerReservation.phoneNumber
                },
                hotel = new
                {
                    hotelId = hotelReservation.hotelId,
                    identificationNumber = hotelReservation.identificationNumber,
                    name = hotelReservation.name,
                    location = hotelReservation.location,
                    address = hotelReservation.address,
                    status = hotelReservation.location,
                    capacityPersons = hotelReservation.capacityPersons,
                    description = hotelReservation.description
                },
                EmergencyContact = new
                {
                    emergencyContactId = emergencyContactReservation.emergencyContactId,
                    firstName = emergencyContactReservation.firstName,
                    lastName = emergencyContactReservation.lastName,
                    phoneNumber = emergencyContactReservation.phoneNumber
                }
            };

            return new CreatedResult($"api/Reservation/{responseReservation.reservation.reservationId}", responseReservation);
        }
    }
}