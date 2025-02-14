using PruebaBackend.Core.Domain.Entities;
using PruebaBackend.Core.Domain.Interfaces;
using PruebaBackend.Infrastructure.Persistence;

namespace PruebaBackend.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task SaveRoom(Room room)
        {
            _context.Add(room);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateRoom(Room room)
        {
            _context.Update(room);
            await _context.SaveChangesAsync();
        }
        public async Task<Room?> FindById(Guid roomId)
        {
            return await _context.rooms.FindAsync(roomId);
        }
    }
}
