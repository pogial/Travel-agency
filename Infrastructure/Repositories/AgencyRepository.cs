using PruebaBackend.Core.Domain.Entities;
using PruebaBackend.Core.Domain.Interfaces;
using PruebaBackend.Infrastructure.Persistence;

namespace PruebaBackend.Infrastructure.Repositories
{
    public class AgencyRepository : IAgencyRepository
    {
        private readonly ApplicationDbContext _context;

        public AgencyRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task SaveAgency(Agency agency)
        {
            _context.Add(agency);
            await _context.SaveChangesAsync();
        }
    }
}
