using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketManager.API.EntityModels
{
    public class Order
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
        public string? PaymentMethodId { get; set; }
        [ForeignKey("PaymentMethodId")]
        [ValidateNever]
        public PaymentMethod PaymentMethod { get; set; }
        public string? TransactionId {  get; set; }
        public string PaymentStatus { get; set; }
        public string? PaymentIntentId { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        public string ShowTimeId { get; set; }
        [ForeignKey("ShowTimeId")]
        [ValidateNever]
        public ShowTime ShowTime { get; set; }
        public double TotalPrice { get; set; }
        public string? OrderStatus { get; set; }
    }
}
