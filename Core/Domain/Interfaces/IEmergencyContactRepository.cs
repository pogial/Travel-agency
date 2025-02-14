using PruebaBackend.Core.Domain.Entities;

namespace PruebaBackend.Core.Domain.Interfaces
{
    public interface IEmergencyContactRepository
    {
        public Task SaveEmergencyContact(EmergencyContact emergencyContact);
        public Task<EmergencyContact?> FindById(Guid emergencyContactId);
    }
}
