using PruebaBackend.Core.Domain.Entities;
using PruebaBackend.Core.Domain.Interfaces;
using PruebaBackend.Infrastructure.Persistence;

namespace PruebaBackend.Infrastructure.Repositories
{
    public class TravelerRepository : ITravelerRepository
    {
        private readonly ApplicationDbContext _context;
        public TravelerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SaveTraveler(Traveler traveler)
        {
            _context.Add(traveler);
            await _context.SaveChangesAsync();
        }
        public async Task<Traveler?> FindById(Guid travelerId)
        {
            return await _context.travelers.FindAsync(travelerId);
        }
    }
}
