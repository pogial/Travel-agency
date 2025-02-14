namespace PruebaBackend.API.DTOs
{
    public class RoomUpdateDto
    {
        public string? roomType { get; private set; } = string.Empty;
        public int? capacityPersons { get; private set; }
        public decimal? baseCost { get; private set; }
        public decimal? taxesPercentage { get; private set; }
        public decimal? price { get; private set; }
    }
}
