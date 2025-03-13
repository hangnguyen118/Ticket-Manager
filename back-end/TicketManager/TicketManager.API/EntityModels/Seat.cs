using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketManager.API.EntityModels
{
    public class Seat
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [StringLength(5)]
        public string Row { get; set; } = string.Empty;
        [Required]
        [StringLength(5)]
        public string Column { get; set; } = string.Empty;
        [Required]
        public string ScreenId { get; set; } = string.Empty;
        [ForeignKey("ScreenId")]
        [ValidateNever]
        public Screen Screen { get; set; } = null!;
        public string? Aisle { get; set; }
        [Required]
        public string SeatType { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
