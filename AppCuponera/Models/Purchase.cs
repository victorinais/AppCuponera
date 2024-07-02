using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppCuponera.Models
{
    public class Purchase 
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal? Amount { get; set; }

        [JsonIgnore]
        public List<CouponUsage>? CouponUsages { get; set; }
    }
}