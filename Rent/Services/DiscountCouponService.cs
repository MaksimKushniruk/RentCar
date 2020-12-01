using Rent.Models;
using Rent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public DiscountCoupon UpdateDiscountCoupon(int id, Dictionary<string, string> fieldsForUpdate)
        {
            List<DiscountCoupon> discountCoupons = discountCouponRepository.GetDiscountCoupon(new DiscountCouponRequest { Id = id });
            discountCoupons.FirstOrDefault().Coupon = fieldsForUpdate["Coupon"];
            discountCoupons.FirstOrDefault().Discount = Int32.Parse(fieldsForUpdate["Discount"]);
            discountCouponRepository.UpdateDiscountCoupon(discountCoupons.FirstOrDefault());
            return discountCoupons.FirstOrDefault();
        }
    }
}
