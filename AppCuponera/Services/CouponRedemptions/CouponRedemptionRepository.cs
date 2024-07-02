using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Data;
using AppCuponera.Models;
using AppCuponera.Services.Redemptions;
using Microsoft.EntityFrameworkCore;

namespace AppCuponera.Services.CouponRedemptions
{
    public class CouponRedemptionRepository : ICouponRedemptionRepository
    {
        private readonly BaseContext _context;
        public CouponRedemptionRepository(BaseContext context)
        {
            _context = context;
        }

        public (bool IsValid, string Message) ValidateCoupon(int userId, int couponId, decimal purchaseAmount)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null || user.UserType != "Customer")
            {
                return(false, "Solo los usuarios con el tipo 'Customer' pueden redimir cupones.");
            }

            var coupon = _context.Coupons
               .Include(c => c.CouponUsages)
               .FirstOrDefault(c => c.Id == couponId);

            if (coupon == null)
            {
                return(false, "Cupón no encontrado");
            }
            
            if (coupon!.Status != "Active")
            {
                return(false, "Cupón no está activo");
            }

            if (coupon.StartDate > DateTime.Now)
            {
                return(false, "Cupón no ha comenzado");
            }

            if (coupon.EndDate < DateTime.Now)
            {
                return(false, "Cupón ha expirado");
            }

            if (coupon.CouponUsages!.Count >= coupon.UsageLimit)
            {
                return(false, "Límite de usos del cupón alcanzado");
            }

            if (coupon.UserId != userId)
            {
                return(false, "Cupón no está asociado al usuario");
            }
            if (purchaseAmount < coupon.MinPurchaseAmount)
            {
                return(false, "Monto de compra inferior al mínimo permitido");
            }

            if (coupon.MaxPurchaseAmount.HasValue && purchaseAmount > coupon.MaxPurchaseAmount.Value)
            {
                return(false, "Monto de compra superior al máximo permitido");
            }

            return (true, "Cupón es válido para ser redimido.");
        }

        public (bool IsRedeemd, string Message) RedeemCoupon(int userId, int couponId, int purchaseId, decimal purchaseAmount)
        {
            var (isValid, message) = ValidateCoupon(userId, couponId, purchaseId);
            if (!isValid)
            {
                return (false, message);
            }

            var couponUsage = new CouponUsage
            {
                CouponId = couponId,
                UserId = userId,
                PurchaseId = purchaseId,
                UsageDate = DateTime.Now,
                TransactionAmount = purchaseAmount
            };

            _context.CouponUsages.Add(couponUsage);
            _context.SaveChanges();

            return (true, "El cupón ha sido redimido exitosamente.");
        }

    }
}