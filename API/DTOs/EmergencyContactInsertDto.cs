using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.API.DTOs
{
    public class EmergencyContactInsertDto
    {
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
    }
}
