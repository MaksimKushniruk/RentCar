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

        public bool DeleteDiscountCoupon(int id)
        {
            return DiscountCouponRepository.DeleteDiscountCoupon(id);
        }

        public List<DiscountCoupon> GetDiscountCoupon(Dictionary<string, string> fields)
        {
            return DiscountCouponRepository.GetDiscountCoupon(new DiscountCouponRequest(Int32.Parse(fields["Id"]),
                                                                                        fields["Coupon"],
                                                                                        Int32.Parse(fields["Minimal discount"]),
                                                                                        Int32.Parse(fields["Maximal discount"])));
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
