using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.Core.Domain.Entities
{
    public class Traveler
    {
        [Key]
        public Guid travelerId { get; private set; }

        [Required]
        [MaxLength(100)]
        public string firstName { get; private set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string lastName { get; private set; } = string.Empty;

        public DateOnly? dateOfBirth { get; private set; }

        [MaxLength(10)]
        public string? gender { get; private set; } = string.Empty;

        [MaxLength(50)]
        public string? documentType { get; private set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string? documentNumber { get; private set; } = string.Empty;

        [MaxLength(100)]
        [EmailAddress]
        public string? email { get; private set; } = string.Empty;

        [MaxLength(20)]
        [Phone]
        public string? phoneNumber { get; private set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime createdAt { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updatedAt { get; private set; }

        public Traveler(string firstName, string lastName, DateOnly? dateOfBirth, string? gender, string? documentType, string documentNumber, 
                        string? email, string? phoneNumber)
        {
            travelerId = Guid.NewGuid();
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.documentType = documentType;
            this.documentNumber = documentNumber;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }
    }
}