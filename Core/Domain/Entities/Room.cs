using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.Core.Domain.Entities
{
    public class Room
    {
        [Key]
        public Guid roomId { get; private set; }

        [Required]
        public Guid hotelId { get; private set; }

        [Required]
        [MaxLength(10)]
        public string roomNumber { get; private set; } = string.Empty;

        [MaxLength(50)]
        public string? roomType { get; private set; } = string.Empty;

        public int? capacityPersons { get; private set; }

        public decimal? baseCost { get; private set; }

        public decimal? taxesPercentage { get; private set; }

        public decimal? price { get; private set; }

        [MaxLength(100)]
        public string? location { get; private set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string status { get; private set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime createdAt { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updatedAt { get; private set; }

        public Room(Guid hotelId, string roomNumber, string? roomType, int? capacityPersons, decimal? baseCost, decimal? taxesPercentage, decimal? price, string? location, string status)
        {
            roomId = Guid.NewGuid();
            this.hotelId = hotelId;
            this.roomNumber = roomNumber;
            this.roomType = roomType;
            this.capacityPersons = capacityPersons;
            this.baseCost = baseCost;
            this.taxesPercentage = taxesPercentage;
            this.price = price;
            this.location = location;
            this.status = status;
        }
        public void UpdateRoom(string? roomType, int? capacityPersons, decimal? baseCost, decimal? taxesPercentage, decimal? price)
        {
            this.roomType = roomType;
            this.capacityPersons = capacityPersons;
            this.baseCost = baseCost;
            this.taxesPercentage = taxesPercentage;
            this.price = price;
        }
        public void UpdateStatusRoom(string status)
        {
            this.status = status;
        }
    }
}