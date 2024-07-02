using System.ComponentModel.DataAnnotations;

namespace AppCuponera.Models
{
    public class CouponUsage
    {
        public int Id { get; set; }
        [Required]
        public int CouponId { get; set; }
        public Coupon? Coupon { get; set; }
        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime UsageDate { get; set; } = DateTime.Now;
        public decimal? TransactionAmount { get; set; }
        public int? PurchaseId { get; set; }
        public Purchase? Purchase { get; set; }
    }
}