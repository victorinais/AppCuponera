using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Data;
using AppCuponera.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCuponera.Services.CouponUsages
{
    public class CouponUsageRepository : ICouponUsageRepository
    {
        public readonly BaseContext _context;
        public CouponUsageRepository(BaseContext context)
        {
            _context = context;
        }

        public void Add(CouponUsage couponUsage)
        {
            var coupon = _context.Coupons.Find(couponUsage.CouponId);

            if (coupon == null || coupon.Status != "Active")
            {
                throw new InvalidOperationException("El cupón no está activo y no puede ser utilizado.");
            }
            
            _context.CouponUsages.Add(couponUsage);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var couponUsage = _context.CouponUsages.Find(id);
            _context.CouponUsages.Remove(couponUsage!);
            _context.SaveChanges();
        }

        public IEnumerable<CouponUsage> GetAll()
        {
            return _context.CouponUsages
                .Include(cu => cu.Coupon)
                .Include(cu => cu.User)
                .ToList();
        }

        public CouponUsage GetById(int id)
        {
            var result = _context.CouponUsages
               .Include(cu => cu.Coupon)
               .Include(cu => cu.User)
               .FirstOrDefault(cu => cu.Id == id);
            return result!;
        }

        public void Update(CouponUsage couponUsage)
        {
            _context.CouponUsages.Update(couponUsage);
            _context.SaveChanges();
        }

        public int GetCouponUsageCount(int couponId)
        {
            return _context.CouponUsages.Where(cu => cu.CouponId == couponId).Count();
        }
    }
}