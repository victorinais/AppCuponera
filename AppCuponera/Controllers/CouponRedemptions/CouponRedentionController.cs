using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Models;
using AppCuponera.Services.Redemptions;
using Microsoft.AspNetCore.Mvc;

namespace AppCuponera.Controllers.CouponRedemptions
{
    public class CouponRedentionController : ControllerBase
    {
        private readonly ICouponRedemptionRepository _couponRedemptionRepository;
        public CouponRedentionController(ICouponRedemptionRepository couponRedemptionRepository)
        {
            _couponRedemptionRepository = couponRedemptionRepository;
        }

        [HttpPost]
        [Route("api/coupons/validate")]
        public IActionResult ValidateCoupon([FromBody] CouponRedemption couponRedemption)
        {
            var (isValid, message) = _couponRedemptionRepository.ValidateCoupon(couponRedemption.UserId, couponRedemption.CouponId, couponRedemption.PurchaseAmount);
            if (isValid)
            {
                return Ok(new { message });
            }
            return BadRequest(new { message });
        }

        [HttpPost]
        [Route("api/coupons/redeemption")]
        public IActionResult RedeemCoupon([FromBody] CouponRedemption couponRedemption)
        {
            var (isRedeemd, message) = _couponRedemptionRepository.RedeemCoupon(couponRedemption.UserId, couponRedemption.CouponId, couponRedemption.PurchaseId, couponRedemption.PurchaseAmount);
            if (isRedeemd)
            {
                return Ok(new { message });
            }
            return BadRequest(new { message });
        }
    }
}