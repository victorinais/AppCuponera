using AppCuponera.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCuponera.Data 
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CouponUsage> CouponUsages { get; set; }
        public DbSet<CouponHistory> CouponHistories { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        
    }
}