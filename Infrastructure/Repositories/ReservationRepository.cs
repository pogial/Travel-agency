using PruebaBackend.API.DTOs;
using PruebaBackend.Core.Domain.Entities;
using PruebaBackend.Core.Domain.Interfaces;
using PruebaBackend.Infrastructure.Persistence;

namespace PruebaBackend.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task SaveReservation(Reservation reservation)
        {
            _context.Add(reservation);
            await _context.SaveChangesAsync();
        }
        public async Task SaveRoomReservation(ReservationRoom reservationRoom)
        {
            _context.Add(reservationRoom);
            await _context.SaveChangesAsync();
        }
        public async Task<Reservation?> FindById(Guid reservationId)
        {
            return await _context.reservations.FindAsync(reservationId);
        }
    }
}
