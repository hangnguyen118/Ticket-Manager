using System.ComponentModel.DataAnnotations;

namespace TicketManager.API.EntityModels
{
    public class ApplicationUser
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string FullName { get; set; }
    }
}
