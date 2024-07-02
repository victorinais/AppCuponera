using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Data;
using AppCuponera.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCuponera.Services.Coupons
{
    public class CouponRepository : ICouponRepository
    {
        public readonly BaseContext _context;
        public CouponRepository(BaseContext context)
        {
            _context = context;
        }

        public void Add(Coupon coupon)
        {
            _context.Coupons.Add(coupon);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var coupon = _context.Coupons.Find(id);
            coupon!.Status = "Inactive";
            _context.Coupons.Update(coupon);
            _context.SaveChanges();
        }

        public IEnumerable<Coupon> GetAll()
        {
            var result = _context.Coupons
                .Include(c => c.User)
                .Where(c => c.Status == "Active" || c.Status == "Inactive")
                .ToList();
            return result;
        }

        public Coupon GetById(int id)
        {
            var result = _context.Coupons
                .Include(c => c.User)
                .Where(c => c.Status == "Active" || c.Status == "Inactive")
                .FirstOrDefault(c => c.Id == id);
            return result!;
        }

        public void Update(Coupon coupon)
        {
            _context.Coupons.Update(coupon);
            _context.SaveChanges();
        }

        public IEnumerable<Coupon> GetListCouponsByCriteria(DateTime? date, string name, string status, string orderBy, bool descending)
        {
            var query = _context.Coupons.Include(c => c.User).AsQueryable();

            if (date.HasValue)
            {
                query = query.Where(c => c.StartDate <= date && c.EndDate >= date);
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Name == name);
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(c => c.Status == status);
            }

            switch (orderBy.ToLower())
            {
                case "name":
                    query = descending ? query.OrderByDescending(c => c.Name) : query.OrderBy(c => c.Name);
                    break;
                case "startdate":
                    query = descending ? query.OrderByDescending(c => c.StartDate) : query.OrderBy(c => c.StartDate);
                    break;
                case "enddate":
                    query = descending ? query.OrderByDescending(c => c.EndDate) : query.OrderBy(c => c.EndDate);
                    break;
                default:
                    query = query.OrderBy(c => c.Id); // Default order
                    break;
            }

            return query.ToList();
        }

        public IEnumerable<Coupon> GetCouponsByUserId(int userId)
        {
            return _context.Coupons
                .Include(c => c.User)
                .Include(c => c.CouponUsages)
                .Where(c => c.User!.Id == userId && (c.Status == "Active" || c.Status == "Inactive"))
                .ToList();
        }

        public Coupon GetCouponDetails(int id)
        {
            var coupon = _context.Coupons
                .Include(c => c.User)
                .Include(c => c.CouponUsages)
                .FirstOrDefault(c => c.Id == id);

            if (coupon != null)
            {
                coupon.CouponUsages = _context.CouponUsages
                    .Where(c => c.CouponId == id)
                    .ToList();
            }

            return coupon!;
        }

    }
}