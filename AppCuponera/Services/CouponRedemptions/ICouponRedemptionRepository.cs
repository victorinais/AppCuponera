using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCuponera.Services.Redemptions
{
    public interface ICouponRedemptionRepository
    {
        (bool IsValid, string Message) ValidateCoupon(int userId, int couponId, decimal purchaseAmount);
        (bool IsRedeemd, string Message) RedeemCoupon(int userId, int couponId, int purchaseId, decimal purchaseAmount);
    }
}