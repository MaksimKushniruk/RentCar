using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface IDiscountCouponService
    {
        int CreateDiscountCoupon(string coupon, int discount);
        bool DeleteDiscountCoupon(int id);
        List<DiscountCoupon> GetDiscountCoupon(Dictionary<string, string> fields);
        bool UpdateDiscountCoupon(int id, Dictionary<string, string> fieldsForUpdate);
    }
}
