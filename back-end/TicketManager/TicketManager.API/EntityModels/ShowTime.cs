using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketManager.API.EntityModels
{
    public class ShowTime
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public string MovieId { get; set; } = string.Empty;
        [ForeignKey(nameof(MovieId))]
        [ValidateNever]
        public Movie Movie { get; set; } = null!;
        public string ScreenId { get; set; } = string.Empty;
        [ForeignKey(nameof(ScreenId))]
        [ValidateNever]
        public Screen Screen { get; set; } = null!;
    }
}
