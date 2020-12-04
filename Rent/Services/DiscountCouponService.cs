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
        /// <summary>
        /// Creating DiscountCoupon. Returns DiscountCoupon object.
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public DiscountCoupon CreateDiscountCoupon(Dictionary<string, string> fields)
        {
            int id = discountCouponRepository.AddDiscountCoupon(new DiscountCoupon(fields["Coupon"], 
                                                                                   Int32.Parse(fields["Discount"])));
            return new DiscountCoupon(id, 
                                      fields["Coupon"], 
                                      Int32.Parse(fields["Discount"]));
        }
        /// <summary>
        ///  Deleting DiscountCoupon. Returns bool result of operation.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteDiscountCoupon(int id)
        {
            return discountCouponRepository.DeleteDiscountCoupon(id);
        }
        /// <summary>
        /// Searching DiscountCoupon. Returns List<DiscountCoupon> with all found coupons.
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public List<DiscountCoupon> GetDiscountCoupon(Dictionary<string, string> fields)
        {
            return discountCouponRepository.GetDiscountCoupon(new DiscountCouponRequest(fields["Id"].ToNullableInt(),
                                                                                        fields["Coupon"],
                                                                                        fields["Minimal discount"].ToNullableInt(),
                                                                                        fields["Maximal discount"].ToNullableInt()));
        }
        /// <summary>
        /// Updating DiscountCoupon. Returns updated object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fieldsForUpdate"></param>
        /// <returns></returns>
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
