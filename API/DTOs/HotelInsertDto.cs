using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.API.DTOs
{
    public class HotelInsertDto
    {
        public string identificationNumber { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public int capacityPersons { get; set; }
        public string description { get; set; } = string.Empty;
    }
}
