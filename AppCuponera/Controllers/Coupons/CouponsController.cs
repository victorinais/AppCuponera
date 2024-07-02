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
    public class CouponsController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;
        private readonly ICouponUsageRepository _couponUsageRepository;
        public CouponsController(ICouponRepository couponRepository, ICouponUsageRepository couponUsageRepository)
        {
            _couponRepository = couponRepository;
            _couponUsageRepository = couponUsageRepository;
        }

        [HttpGet]
        [Route("api/coupons")]
        public IEnumerable<Coupon> GetCoupons()
        {
            return _couponRepository.GetAll();
        }

        [HttpGet]
        [Route("api/coupons/{id}")]
        public Coupon GetCouponById(int id)
        {
            return _couponRepository.GetById(id);
        }

        [HttpGet]
        [Route("api/coupons/list")]
        public ActionResult<IEnumerable<Coupon>> GetListCouponsByCriteria(DateTime? date,string name, string status = null!, string orderBy = "id",bool descending = false)
        {
            var result = _couponRepository.GetListCouponsByCriteria(date, name, status, orderBy, descending);
            return Ok(new { message = $"Se encontraron {result.Count()} cupones.", cupones = result });
        }

        [HttpGet]
        [Route("api/user/{userId}")]
        public IActionResult GetUserCoupons(int userId)
        {
            var coupons = _couponRepository.GetCouponsByUserId(userId);

            var couponDetails = coupons.Select(coupon => new
            {
                coupon.Id,
                coupon.Name,
                coupon.Description,
                coupon.StartDate,
                coupon.EndDate,
                coupon.DiscountType,
                coupon.DiscountValue,
                coupon.UsageLimit,
                coupon.Status,
                UsageCount = _couponUsageRepository.GetCouponUsageCount(coupon.Id)
            }).ToList();

            return Ok(new 
            { 
                message = $"El usuario {userId} ha creado {couponDetails.Count()} cupones.", 
                cupones = couponDetails 
            });
        }

        [HttpGet]
        [Route("api/coupons/details/{id}")]
        public IActionResult GetCouponDetails(int id)
        {
            var coupon = _couponRepository.GetCouponDetails(id);

            if (coupon == null)
            {
                return NotFound(new { message = "No se encontró el cupón." });
            }

            var usageCount = _couponUsageRepository.GetCouponUsageCount(id);
            var canEditOrDelete = usageCount == 0;

            return Ok(new
            {
                coupon = new
                {
                    coupon.Name,
                    coupon.Description,
                    coupon.StartDate,
                    coupon.EndDate,
                    coupon.DiscountType,
                    coupon.DiscountValue,
                    coupon.UsageLimit,
                    usageCount = usageCount
                },
                canEditOrDelete
            });
        }
    }
}