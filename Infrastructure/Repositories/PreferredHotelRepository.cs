using PruebaBackend.Core.Domain.Entities;
using PruebaBackend.Core.Domain.Interfaces;
using PruebaBackend.Infrastructure.Persistence;

namespace PruebaBackend.Infrastructure.Repositories
{
    public class PreferredHotelRepository : IPreferredHotelRepository
    {
        private readonly ApplicationDbContext _context;
        public PreferredHotelRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task SavePreferredHotel(PreferredHotel preferredHotel)
        {
            _context.Add(preferredHotel);
            await _context.SaveChangesAsync();
        }
    }
}
