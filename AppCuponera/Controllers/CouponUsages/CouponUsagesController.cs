using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Models;
using AppCuponera.Services.CouponUsages;
using Microsoft.AspNetCore.Mvc;

namespace AppCuponera.Controllers.CouponUsages
{
    public class CouponUsagesController : ControllerBase
    {
        private readonly ICouponUsageRepository _couponUsageRepository;
        public CouponUsagesController(ICouponUsageRepository couponUsageRepository)
        {
            _couponUsageRepository = couponUsageRepository;
        }

        [HttpGet]
        [Route("api/coupon/usages")]
        public IEnumerable<CouponUsage> GetCouponUsages()
        {
            return _couponUsageRepository.GetAll();
        }

        [HttpGet]
        [Route("api/coupon/usages/{id}")]
        public CouponUsage GetCouponUsageById(int id)
        {
            return _couponUsageRepository.GetById(id);
        }

        [HttpGet]
        [Route("api/usages/list/{couponId}")]
        public ActionResult GetCouponUsagesByCouponId(int couponId)
        {
            var result = _couponUsageRepository.GetCouponUsageCount(couponId);
            return Ok(new { message = $"Se encontraron {result} usos de cupón."} );
        }
    }
}