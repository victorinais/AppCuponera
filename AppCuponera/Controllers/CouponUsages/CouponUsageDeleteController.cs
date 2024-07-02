using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Services.CouponUsages;
using Microsoft.AspNetCore.Mvc;

namespace AppCuponera.Controllers.CouponUsages
{
    public class CouponUsageDeleteController : ControllerBase
    {
        private readonly ICouponUsageRepository _couponUsageRepository;
        public CouponUsageDeleteController(ICouponUsageRepository couponUsageRepository)
        {
            _couponUsageRepository = couponUsageRepository;
        }

        [HttpDelete]
        [Route("api/usages/delete/{id}")]
        public IActionResult DeleteCouponUsage(int id)
        {
            _couponUsageRepository.Delete(id);
            return Ok(new { message = "El cupón se eliminó éxitosamente."});
        }
    }
}