using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Models;
using AppCuponera.Services.CouponUsages;
using Microsoft.AspNetCore.Mvc;

namespace AppCuponera.Controllers.CouponUsages
{
    public class CouponUsageUpdateController : ControllerBase
    {
        private readonly ICouponUsageRepository _couponUsageRepository;
        public CouponUsageUpdateController(ICouponUsageRepository couponUsageRepository)
        {
            _couponUsageRepository = couponUsageRepository;
        }

        [HttpPut]
        [Route("api/usages/update/{id}")]
        public IActionResult UpdateCouponUsage(int id, [FromBody] CouponUsage couponUsage)
        {
            var couponUsageToUpdate = _couponUsageRepository.GetById(id);

            couponUsageToUpdate.CouponId = couponUsage.CouponId;
            couponUsageToUpdate.UserId = couponUsage.UserId;
            couponUsageToUpdate.UsageDate = couponUsage.UsageDate;
            couponUsageToUpdate.TransactionAmount = couponUsage.TransactionAmount;

            _couponUsageRepository.Update(couponUsageToUpdate);
            return Ok(new { message = "El uso del cupón se actulizó éxitosamente."});

        }
    }
}