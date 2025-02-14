using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.Core.Domain.Entities
{
    public class Reservation
    {
        [Key]
        public Guid reservationId { get; private set; }

        [Required]
        public Guid travelerId { get; private set; }

        [Required]
        public Guid hotelId { get; private set; }

        [Required]
        public DateTime checkIn { get; private set; }

        [Required]
        public DateTime checkOut { get; private set; }

        [MaxLength(20)]
        public string? status { get; private set; } = string.Empty;

        public Guid? emergencyContactId { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime createdAt { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updatedAt { get; private set; }
        public Reservation(Guid travelerId, Guid hotelId, DateTime checkIn, DateTime checkOut, Guid? emergencyContactId, string status)
        {
            reservationId = Guid.NewGuid();
            this.status = status;
            this.travelerId = travelerId;
            this.hotelId = hotelId;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
            this.emergencyContactId = emergencyContactId;
        }
    }
}
