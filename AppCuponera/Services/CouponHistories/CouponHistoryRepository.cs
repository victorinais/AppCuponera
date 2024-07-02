using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Data;
using AppCuponera.Models;

namespace AppCuponera.Services.CouponHistories
{
    public class CouponHistoryRepository : ICouponHistoryRepository
    {
        public readonly BaseContext _context;
        public CouponHistoryRepository(BaseContext context)
        {
            _context = context;
        }
        
        public void Add(CouponHistory couponHistory)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CouponHistory> GetAll()
        {
            throw new NotImplementedException();
        }

        public CouponHistory GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CouponHistory couponHistory)
        {
            throw new NotImplementedException();
        }
    }
}