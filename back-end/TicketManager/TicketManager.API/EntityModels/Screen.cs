using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketManager.API.EntityModels
{
    public class Screen
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string ScreenNumber { get; set; } = string.Empty;
        [Required]
        public int Capacity { get; set; }
        [Required]
        public string CinemaId { get; set; } = string.Empty;
        [ForeignKey(nameof(CinemaId))]
        [ValidateNever]
        public Cinema Cinema { get; set; } = null!;
    }
}
