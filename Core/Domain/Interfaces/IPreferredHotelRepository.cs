using PruebaBackend.Core.Domain.Entities;

namespace PruebaBackend.Core.Domain.Interfaces
{
    public interface IPreferredHotelRepository
    {
        public Task SavePreferredHotel(PreferredHotel preferredHotel);
    }
}
