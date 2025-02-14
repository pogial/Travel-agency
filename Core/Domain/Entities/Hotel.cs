using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaBackend.Core.Domain.Entities
{
    public class Hotel
    {
        [Key]
        public Guid hotelId { get; private set; }

        [Required]
        [MaxLength(50)]
        public string identificationNumber { get; private set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string name { get; private set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string location { get; private set; } = string.Empty;

        [MaxLength(255)]
        public string address { get; private set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string? status { get; private set; } = string.Empty;

        [Required]
        public int capacityPersons { get; private set; }
        public string? description { get; private set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime createdAt { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updatedAt { get; private set; }

        public Hotel(string identificationNumber, string name, string location, string address, int capacityPersons, string? description, string status)
        {
            hotelId = Guid.NewGuid();
            this.status = status;
            this.identificationNumber = identificationNumber;
            this.name = name;
            this.location = location;
            this.address = address;
            this.capacityPersons = capacityPersons;
            this.description = description;
        }
        public void UpdateHotel(string identificationNumber, string name, string location, string address, int capacityPersons, string? description)
        {
            this.identificationNumber = identificationNumber;
            this.name = name;
            this.location = location;
            this.address = address;
            this.capacityPersons = capacityPersons;
            this.description = description;
        }
        public void UpdateStatusHotel(string status)
        {
            this.status = status;
        }
    }
}