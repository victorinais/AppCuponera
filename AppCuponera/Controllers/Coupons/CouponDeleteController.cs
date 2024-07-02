using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Services.Coupons;
using AppCuponera.Services.CouponUsages;
using Microsoft.AspNetCore.Mvc;

namespace AppCuponera.Controllers.Coupons
{
    public class CouponDeleteController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;
        private readonly ICouponUsageRepository _couponUsageRepository;
        public CouponDeleteController(ICouponRepository couponRepository, ICouponUsageRepository couponUsageRepository)
        {
            _couponRepository = couponRepository;
            _couponUsageRepository = couponUsageRepository;
        }

        [HttpDelete]
        [Route("api/coupons/delete/{id}")]
        public IActionResult DeleteCoupon(int id)
        {
            var coupon = _couponRepository.GetById(id);

            if (coupon == null)
            {
                return NotFound(new { message = "Cupón no encontrado." });
            }

            var usageCount = _couponUsageRepository.GetCouponUsageCount(id);
            if (usageCount > 0)
            {
                return BadRequest(new { message = "No se puede eliminar el cupón porque ya ha sido utilizado." });
            }

            _couponRepository.Delete(id);
            return Ok(new { message = "El coupon se eliminó exitosamente."});
        }
    }
}