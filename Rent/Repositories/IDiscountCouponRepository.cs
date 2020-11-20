using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Repositories
{
    public interface IDiscountCouponRepository
    {
        bool AddDiscountCoupon(DiscountCoupon discountCoupon, out int id);
        bool DeleteDiscountCoupon(int id);
        public List<DiscountCoupon> GetDiscountCoupon(DiscountCouponRequest request);
        bool UpdateDiscountCoupon(DiscountCoupon discountCoupon);
    }
}
