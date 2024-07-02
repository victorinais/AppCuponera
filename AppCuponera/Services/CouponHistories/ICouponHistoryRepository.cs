using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Models;

namespace AppCuponera.Services.CouponHistories
{
    public interface ICouponHistoryRepository
    {
        IEnumerable<CouponHistory> GetAll();
        CouponHistory GetById(int id);
        void Add(CouponHistory couponHistory);
        void Update(CouponHistory couponHistory);
        void Delete(int id);
    }
}