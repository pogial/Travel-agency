using PruebaBackend.Core.Domain.Entities;
using PruebaBackend.Core.Domain.Interfaces;
using PruebaBackend.Infrastructure.Persistence;

namespace PruebaBackend.Infrastructure.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDbContext _context;

        public HotelRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task SaveHotel(Hotel hotel)
        {
            _context.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Update(hotel);
            await _context.SaveChangesAsync();
        }
        public async Task<Hotel?> FindById(Guid hotelId)
        {
            return await _context.hotels.FindAsync(hotelId); 
        }
    }
}
