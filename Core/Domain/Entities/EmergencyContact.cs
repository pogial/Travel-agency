using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.Core.Domain.Entities
{
    public class EmergencyContact
    {
        [Key]
        public Guid emergencyContactId { get; private set; }

        [Required]
        [MaxLength(100)]
        public string firstName { get; private set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string lastName { get; private set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        [Phone]
        public string phoneNumber { get; private set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime createdAt { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updatedAt { get; private set; }
        public EmergencyContact(string firstName, string lastName, string phoneNumber)
        {
            emergencyContactId = Guid.NewGuid();
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
        }
    }
}
