using PruebaBackend.API.DTOs;
using PruebaBackend.Core.Domain.Entities;

namespace PruebaBackend.Core.Domain.Interfaces
{
    public interface IReservationRepository
    {
        public Task SaveReservation(Reservation reservation);
        public Task SaveRoomReservation(ReservationRoom reservationRoom);
        public Task<Reservation?> FindById(Guid reservationId);
    }
}
