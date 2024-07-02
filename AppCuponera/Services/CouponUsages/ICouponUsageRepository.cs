using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Models;

namespace AppCuponera.Services.CouponUsages
{
    public interface ICouponUsageRepository
    {
        IEnumerable<CouponUsage> GetAll();
        CouponUsage GetById(int id);
        void Add(CouponUsage couponUsage);
        void Update(CouponUsage couponUsage);
        void Delete(int id);

        int GetCouponUsageCount(int couponId);
    }
}