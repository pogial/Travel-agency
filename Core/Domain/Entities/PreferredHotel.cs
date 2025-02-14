using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace PruebaBackend.Core.Domain.Entities
{
    public class PreferredHotel
    {
        [Key, Column(Order = 0)]
        public Guid agencyId { get; private set; }

        [Key, Column(Order = 1)]
        public Guid hotelId { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime createdAt { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updatedAt { get; private set; }

        public PreferredHotel(Guid agencyId, Guid hotelId)
        {
            this.agencyId = agencyId;
            this.hotelId = hotelId;
        }
    }
}
