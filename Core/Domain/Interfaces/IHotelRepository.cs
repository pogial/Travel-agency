using PruebaBackend.Core.Domain.Entities;

namespace PruebaBackend.Core.Domain.Interfaces
{
    public interface IHotelRepository
    {
        public Task SaveHotel(Hotel hotel);
        public Task UpdateHotel(Hotel hotel);
        public Task<Hotel?> FindById(Guid hotelId);
    }
}
