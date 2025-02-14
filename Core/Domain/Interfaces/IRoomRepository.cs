using PruebaBackend.Core.Domain.Entities;

namespace PruebaBackend.Core.Domain.Interfaces
{
    public interface IRoomRepository
    {
        public Task SaveRoom(Room room);
        public Task UpdateRoom(Room room);
        public Task<Room?> FindById(Guid roomId);
    }
}
