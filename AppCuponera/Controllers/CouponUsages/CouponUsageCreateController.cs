using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Models;
using AppCuponera.Services.CouponUsages;
using Microsoft.AspNetCore.Mvc;

namespace AppCuponera.Controllers.CouponUsages
{
    public class CouponUsageCreateController : ControllerBase
    {
        private readonly ICouponUsageRepository _couponUsageRepository;
        public CouponUsageCreateController(ICouponUsageRepository couponUsageRepository)
        {
            _couponUsageRepository = couponUsageRepository;
        }

        [HttpPost]
        [Route("api/usages/create")]
        public IActionResult CreateCouponUsage([FromBody] CouponUsage couponUsage)
        {
            try
            {
                _couponUsageRepository.Add(couponUsage);
                return Ok(new { message = "El uso de cupón se ha creado éxitosamente.", couponUsage = couponUsage });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}