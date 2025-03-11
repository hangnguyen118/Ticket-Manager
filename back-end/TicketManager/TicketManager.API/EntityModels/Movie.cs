using System.ComponentModel.DataAnnotations;

namespace TicketManager.API.EntityModels
{
    public class Movie
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]  
        public string Description { get; set; }
        [Required]  
        public string Genre { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public float Rating { get; set; }
        public int Duration { get; set; }
    }
}
