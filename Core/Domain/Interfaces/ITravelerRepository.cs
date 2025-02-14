using PruebaBackend.Core.Domain.Entities;

namespace PruebaBackend.Core.Domain.Interfaces
{
    public interface ITravelerRepository
    {
        public Task SaveTraveler(Traveler traveler);
        public Task<Traveler?> FindById(Guid travelerId);
    }
}
