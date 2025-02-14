using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.API.DTOs
{
    public class PreferredHotelInsertDto
    {
        public Guid agencyId { get; set; }
        public Guid hotelId { get; set; }
    }
}
