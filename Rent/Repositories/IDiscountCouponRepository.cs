using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Repositories
{
    public interface IDiscountCouponRepository
    {
        int AddDiscountCoupon(DiscountCoupon discountCoupon);
        bool DeleteDiscountCoupon(int id);
        public List<DiscountCoupon> GetDiscountCoupon(DiscountCouponRequest request);
        bool UpdateDiscountCoupon(DiscountCoupon discountCoupon);
    }
}
