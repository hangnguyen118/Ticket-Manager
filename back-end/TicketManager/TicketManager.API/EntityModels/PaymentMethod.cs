using System.ComponentModel.DataAnnotations;

namespace TicketManager.API.EntityModels
{
    public class PaymentMethod
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
