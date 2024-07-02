using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Models;

namespace AppCuponera.Services.Coupons
{
    public interface ICouponRepository
    {
        IEnumerable<Coupon> GetAll();
        Coupon GetById(int id);
        void Add(Coupon coupon);
        void Update(Coupon coupon);
        void Delete(int id);

        // Nuevo método para obtener cupones por criterio
        IEnumerable<Coupon> GetListCouponsByCriteria(DateTime? date, string name, string status, string orderBy, bool descending);

        // Nuevo método para obtener cupones por usuario
        IEnumerable<Coupon> GetCouponsByUserId(int userId);

        // Nuevo método para obtener detalles especificos de cupones por id
        Coupon GetCouponDetails(int id);
    }
}