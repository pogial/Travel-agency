using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.API.DTOs
{
    public class GuestInsertDto
    {
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string? email { get; set; } = string.Empty;
        public string? phone { get; set; } = string.Empty;
        public DateOnly? dateOfBirth { get; set; }
        public string? nationality { get; set; } = string.Empty;
        public string? gender { get; set; } = string.Empty;
    }
}
