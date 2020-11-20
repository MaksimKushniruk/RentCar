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

        public bool CreateDiscountCoupon(out int discountCouponId, string coupon, int discount)
        {
            bool result = DiscountCouponRepository.AddDiscountCoupon(new DiscountCoupon(coupon, discount), out int id);
            discountCouponId = id;
            return result;
        }

        public bool DeleteDiscountCoupon(int id)
        {
            return DiscountCouponRepository.DeleteDiscountCoupon(id);
        }

        public List<DiscountCoupon> GetDiscountCoupon(DiscountCouponRequest request)
        {
            return DiscountCouponRepository.GetDiscountCoupon(request);
        }

        public bool UpdateDiscountCoupon(int id, Dictionary<string, string> fieldsForUpdate)
        {
            List<DiscountCoupon> discountCoupons = DiscountCouponRepository.GetDiscountCoupon(new DiscountCouponRequest { Id = id });
            if (fieldsForUpdate.ContainsKey("Coupon"))
            {
                discountCoupons[0].Coupon = fieldsForUpdate["Coupon"];
            }
            if (fieldsForUpdate.ContainsKey("Discount"))
            {
                discountCoupons[0].Discount = int.Parse(fieldsForUpdate["Discount"]);
            }
            return DiscountCouponRepository.UpdateDiscountCoupon(discountCoupons[0]);
        }
    }
}
