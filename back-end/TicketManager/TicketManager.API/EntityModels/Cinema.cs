using System.ComponentModel.DataAnnotations;

namespace TicketManager.API.EntityModels
{
    public class Cinema
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string City { get; set; }
        [Required]
        [MaxLength(255)]
        public string State { get; set; }
        [Required]        
        public string StreetAddress { get; set; }
    }
}
