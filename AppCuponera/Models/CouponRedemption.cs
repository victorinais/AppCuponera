using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCuponera.Models
{
    public class CouponRedemption
    {
        public int UserId { get; set; }
        public int CouponId { get; set; }
        public int PurchaseId { get; set; }
        public decimal PurchaseAmount { get; set; }
    }
}