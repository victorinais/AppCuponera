using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Models;
using AppCuponera.Services.Coupons;
using AppCuponera.Services.CouponUsages;
using Microsoft.AspNetCore.Mvc;

namespace AppCuponera.Controllers.Coupons
{
    public class CouponUpdateController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;
        private readonly ICouponUsageRepository _couponUsageRepository;
        public CouponUpdateController(ICouponRepository couponRepository, ICouponUsageRepository couponUsageRepository)
        {
            _couponRepository = couponRepository;
            _couponUsageRepository = couponUsageRepository;
        }

        [HttpPut]
        [Route("api/coupons/update/{id}")]
        public IActionResult UpdateCoupon(int id, [FromBody] Coupon coupon)
        {
            var couponToUpdate = _couponRepository.GetById(id);

            if (couponToUpdate == null)
            {
                return NotFound(new { message = "Cupón no encontrado." });
            }

            var usageCount = _couponUsageRepository.GetCouponUsageCount(id);
            if (usageCount > 0)
            {
                return BadRequest(new { message = "No se puede actualizar el cupón porque ya se ha utilizado." });
            }

            couponToUpdate.Name = coupon.Name;
            couponToUpdate.Description = coupon.Description;
            couponToUpdate.StartDate = coupon.StartDate;
            couponToUpdate.EndDate = coupon.EndDate;
            couponToUpdate.DiscountType = coupon.DiscountType;
            couponToUpdate.DiscountValue = coupon.DiscountValue;
            couponToUpdate.UsageLimit = coupon.UsageLimit;
            couponToUpdate.MinPurchaseAmount = coupon.MinPurchaseAmount;
            couponToUpdate.MaxPurchaseAmount = coupon.MaxPurchaseAmount;
            couponToUpdate.Status = coupon.Status;
            //couponToUpdate.UserId = coupon.UserId;

            _couponRepository.Update(couponToUpdate);
            return Ok(new { message = "El cupón se actulizó éxitosamente." });
        }
    }
}