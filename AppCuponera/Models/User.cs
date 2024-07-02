using System.Text.Json.Serialization;

namespace AppCuponera.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? UserType { get; set; }

        [JsonIgnore]
        public List<Coupon>? Coupons { get; set; }
        
        [JsonIgnore]
        public List<UserRole>? UserRoles { get; set; }

        [JsonIgnore]
        public List<CouponUsage>? CouponUsages { get; set; }

        [JsonIgnore]
        public List<Purchase>? Purchases { get; set; }
    }
}