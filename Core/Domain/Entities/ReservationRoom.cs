using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.Core.Domain.Entities
{
    public class ReservationRoom
    {
        [Key, Column(Order = 0)]
        public Guid reservationId { get; private set; }

        [Key, Column(Order = 1)]
        public Guid roomId { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime createdAt { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updatedAt { get; private set; }
        public ReservationRoom(Guid reservationId, Guid roomId)
        {
            this.reservationId = reservationId;
            this.roomId = roomId;
        }
    }
}
