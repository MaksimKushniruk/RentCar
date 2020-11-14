using Rent.Models;
using Rent.Repositories;
using System;
using System.Collections.Generic;

namespace Rent.Services
{
    public class DiscountCouponService : IDiscountCouponService
    {
        private IDiscountCouponRepository DiscountCouponRepository = new DiscountCouponRepository();
        public DiscountCouponService()
        {
            DiscountCouponRepository = new DiscountCouponRepository();
        }

        public int CreateDiscountCoupon(string coupon, int discount)
        {
            return DiscountCouponRepository.AddDiscountCoupon(new DiscountCoupon(coupon, discount));
        }

        public int DeleteDiscountCoupon(int id)
        {
            return DiscountCouponRepository.DeleteDiscountCoupon(id);
        }

        public DiscountCoupon GetDiscountCoupon(int id)
        {
            return DiscountCouponRepository.GetDiscountCoupon(id);
        }

        public List<DiscountCoupon> GetDiscountCoupon()
        {
            return DiscountCouponRepository.GetDiscountCoupon();
        }

        public int UpdateDiscountCoupon(DiscountCoupon discountCoupon)
        {
            return DiscountCouponRepository.UpdateDiscountCoupon(discountCoupon);
        }
    }
}
