using System.ComponentModel.DataAnnotations;

namespace TicketManager.API.EntityModels.Dto.Cinema
{
    public abstract class BaseCinemaDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string City { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string State { get; set; } = string.Empty;
        [Required]
        public string StreetAddress { get; set; } = string.Empty;
    }
}
