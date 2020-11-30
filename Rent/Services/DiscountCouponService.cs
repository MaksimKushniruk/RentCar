using Rent.Models;
using Rent.Repositories;
using System;
using System.Collections.Generic;

namespace Rent.Services
{
    public class DiscountCouponService : IDiscountCouponService
    {
        private IDiscountCouponRepository discountCouponRepository = new DiscountCouponRepository();
        public DiscountCouponService()
        {
            discountCouponRepository = new DiscountCouponRepository();
        }

        public DiscountCoupon CreateDiscountCoupon(Dictionary<string, string> fields)
        {
            int id = discountCouponRepository.AddDiscountCoupon(new DiscountCoupon(fields["Coupon"], 
                                                                                   Int32.Parse(fields["Discount"])));
            return new DiscountCoupon(id, 
                                      fields["Coupon"], 
                                      Int32.Parse(fields["Discount"]));
        }

        public bool DeleteDiscountCoupon(int id)
        {
            return discountCouponRepository.DeleteDiscountCoupon(id);
        }

        public List<DiscountCoupon> GetDiscountCoupon(Dictionary<string, string> fields)
        {
            return discountCouponRepository.GetDiscountCoupon(new DiscountCouponRequest(Int32.Parse(fields["Id"]),
                                                                                        fields["Coupon"],
                                                                                        Int32.Parse(fields["Minimal discount"]),
                                                                                        Int32.Parse(fields["Maximal discount"])));
        }

        public bool UpdateDiscountCoupon(int id, Dictionary<string, string> fieldsForUpdate)
        {
            List<DiscountCoupon> discountCoupons = discountCouponRepository.GetDiscountCoupon(new DiscountCouponRequest { Id = id });
            if (fieldsForUpdate.ContainsKey("Coupon"))
            {
                discountCoupons[0].Coupon = fieldsForUpdate["Coupon"];
            }
            if (fieldsForUpdate.ContainsKey("Discount"))
            {
                discountCoupons[0].Discount = int.Parse(fieldsForUpdate["Discount"]);
            }
            return discountCouponRepository.UpdateDiscountCoupon(discountCoupons[0]);
        }
    }
}
