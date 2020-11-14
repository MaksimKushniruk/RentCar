using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface IDiscountCouponService
    {
        int CreateDiscountCoupon(string coupon, int discount);
        int DeleteDiscountCoupon(int id);
        DiscountCoupon GetDiscountCoupon(int id);
        List<DiscountCoupon> GetDiscountCoupon();
        int UpdateDiscountCoupon(DiscountCoupon discountCoupon);
    }
}
