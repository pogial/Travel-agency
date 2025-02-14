using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaBackend.Core.Domain.Entities
{
    public class Agency
    {
        [Key]
        public Guid agencyId { get; private set; }

        [Required]
        [MaxLength(100)]
        public string? name { get; private set; } = string.Empty;

        [MaxLength(255)]
        public string? address { get; private set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string? email { get; private set; } = string.Empty;

        [MaxLength(20)]
        [Phone]
        public string? phone { get; private set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime createdAt { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updatedAt { get; private set; }
        private Agency() { }
        public Agency(string name, string? address, string email, string? phone)
        {
            agencyId = Guid.NewGuid();
            this.name = name;
            this.address = address;
            this.email = email;
            this.phone = phone;
        }
    }
}