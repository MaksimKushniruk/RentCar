using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Repositories
{
    public interface IDiscountCouponRepository
    {
        int AddDiscountCoupon(DiscountCoupon discountCoupon);
        int DeleteDiscountCoupon(int id);
        public List<DiscountCoupon> GetDiscountCoupon(DiscountCouponRequest request);
        int UpdateDiscountCoupon(DiscountCoupon discountCoupon);
    }
}
