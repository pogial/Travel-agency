using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.API.DTOs
{
    public class ReservationInsertDto
    {
        public Guid travelerId { get; set; }
        public Guid hotelId { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public List<Guid> roomIds { get; set; } = new List<Guid>();
        public List<GuestInsertDto> guests { get; set; } = new List<GuestInsertDto>();
        public EmergencyContactInsertDto? emergencyContact {  get; set; }
    }
}
