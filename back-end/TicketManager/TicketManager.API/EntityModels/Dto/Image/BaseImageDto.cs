using System.ComponentModel.DataAnnotations;
namespace TicketManager.API.EntityModels.Dto.Image
{
    public abstract class BaseImageDto
    {        
        [Required]
        public string ImageUrl { get; set; } = string.Empty;        
    }
}
