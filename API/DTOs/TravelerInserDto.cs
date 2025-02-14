using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.API.DTOs
{
    public class TravelerInserDto
    {
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public DateOnly? dateOfBirth { get; set; }
        public string gender { get; set; } = string.Empty;
        public string documentType { get; set; } = string.Empty;
        public string documentNumber { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
    }
}
