using System.ComponentModel.DataAnnotations;

namespace TicketManager.API.EntityModels.Dto.ApplicationUser
{
    public abstract class BaseAppllicationUseDto
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
    }
}
