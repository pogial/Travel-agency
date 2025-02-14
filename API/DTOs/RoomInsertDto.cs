using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.API.DTOs
{
    public class RoomInsertDto
    {
        public Guid hotelId { get; set; }
        public string roomNumber { get; set; } = string.Empty;
        public string? roomType { get; set; } = string.Empty;
        public int? capacityPersons { get; set; }
        public decimal? baseCost { get; set; }
        public decimal? taxesPercentage { get; set; }
        public decimal? price { get; set; }
        public string? location { get; set; } = string.Empty;
    }
}
