using Microsoft.EntityFrameworkCore;
using PruebaBackend.Core.Domain.Entities;
using PruebaBackend.Core.Domain.Interfaces;
using PruebaBackend.Infrastructure.Persistence;

namespace PruebaBackend.Infrastructure.Repositories
{
    public class EmergencyContactRepository : IEmergencyContactRepository
    {
        private readonly ApplicationDbContext _context;

        public EmergencyContactRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task SaveEmergencyContact(EmergencyContact emergencyContact)
        {
            _context.Add(emergencyContact);
            await _context.SaveChangesAsync();
        }
        public async Task<EmergencyContact?> FindById(Guid emergencyContactId)
        {
            return await _context.emergencycontacts.FindAsync(emergencyContactId);
        }
    }
}
