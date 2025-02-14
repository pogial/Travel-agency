using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaBackend.Core.Domain.Entities
{
    public class Guest
    {
        [Key]
        public Guid guestId { get; private set; }

        [Required]
        public Guid reservationId { get; private set; }

        [Required]
        [MaxLength(100)]
        public string firstName { get; private set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string lastName { get; private set; } = string.Empty;

        [MaxLength(100)]
        public string? email { get; private set; } = string.Empty;

        [MaxLength(20)]
        public string? phone { get; private set; } = string.Empty;

        public DateOnly? dateOfBirth { get; private set; }

        [MaxLength(50)]
        public string? nationality { get; private set; } = string.Empty;

        [MaxLength(10)]
        public string? gender { get; private set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime createdAt { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updatedAt { get; private set; }
        public Guest(Guid reservationId, string firstName, string lastName, string? email, string? phone, DateOnly? dateOfBirth, string? nationality, string? gender)
        {
            guestId = Guid.NewGuid();
            this.reservationId = reservationId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.dateOfBirth = dateOfBirth;
            this.nationality = nationality;
            this.gender = gender;
        }
    }
}