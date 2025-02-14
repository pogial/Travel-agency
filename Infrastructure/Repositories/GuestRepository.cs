using Microsoft.EntityFrameworkCore;
using PruebaBackend.Core.Domain.Entities;
using PruebaBackend.Core.Domain.Interfaces;
using PruebaBackend.Infrastructure.Persistence;

namespace PruebaBackend.Infrastructure.Repositories
{
    public class GuestRepository: IGuestRepository
    {
        private readonly ApplicationDbContext _context;

        public GuestRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task SaveGuest(Guest guest)
        {
            _context.Add(guest);
            await _context.SaveChangesAsync();
        }
        public async Task<Guest?> FindById(Guid guestId)
        {
            return await _context.guests.FindAsync(guestId);
        }
    }
}
