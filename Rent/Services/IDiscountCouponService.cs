using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface IDiscountCouponService
    {
        int CreateDiscountCoupon(string coupon, int discount);
        bool DeleteDiscountCoupon(int id);
        List<DiscountCoupon> GetDiscountCoupon(DiscountCouponRequest request);
        bool UpdateDiscountCoupon(int id, Dictionary<string, string> fieldsForUpdate);
    }
}
