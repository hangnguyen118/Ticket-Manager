using System.ComponentModel.DataAnnotations;

namespace TicketManager.API.EntityModels.Dto.Movie
{
    public abstract class BaseMovieDto
    {        
        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Genre { get; set; } = string.Empty;
        [Required]
        public DateTime ReleaseDate { get; set; }       
        public int Duration { get; set; }
    }
}
