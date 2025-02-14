using PruebaBackend.Core.Domain.Entities;

namespace PruebaBackend.Core.Domain.Interfaces
{
    public interface IGuestRepository
    {
        public Task SaveGuest(Guest guest);
        public Task<Guest?> FindById(Guid guestId);
    }
}
