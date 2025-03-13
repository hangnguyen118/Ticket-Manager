using System.ComponentModel.DataAnnotations;

namespace TicketManager.API.EntityModels.Dto.Image
{
    public class CreateImageDto : BaseImageDto
    {
        public string? MovieId { get; set; }
        public string? ApplicationUserId { get; set; }
        [Required]
        public string ImageType { get; set; } = string.Empty;
    }
}
