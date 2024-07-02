using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppCuponera.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "La fecha de finalización es obligatoria.")]
        public DateTime EndDate { get; set; }
        public string? DiscountType { get; set; }
        public decimal? DiscountValue { get; set; }
        public int UsageLimit { get; set; }
        public decimal? MinPurchaseAmount { get; set; }
        public decimal? MaxPurchaseAmount { get; set; }
        [Required(ErrorMessage = "El estado es obligatorio.")]
        public string? Status { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        [JsonIgnore]
        public List<CouponUsage>? CouponUsages { get; set; }
        [JsonIgnore]
        public List<CouponHistory>? CouponHistories { get; set; }
    }
}