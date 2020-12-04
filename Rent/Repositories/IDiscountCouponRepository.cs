using System.Collections.Generic;
using Rent.Models;

namespace Rent.Repositories
{
    public interface IDiscountCouponRepository
    {
        /// <summary>
        /// Adding object to database. Returns id of added DiscountCoupon.
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        int AddDiscountCoupon(DiscountCoupon discountCoupon);
        /// <summary>
        /// Deleting DiscountCoupon from database. Returns bool result of operation.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteDiscountCoupon(int id);
        /// <summary>
        /// Searching DiscountCoupon or DiscountCoupons in database. Returns all found DiscountCoupons.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<DiscountCoupon> GetDiscountCoupon(DiscountCouponRequest request);
        /// <summary>
        /// Updating DiscountCoupon in database. Returns bool result of operation.
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        bool UpdateDiscountCoupon(DiscountCoupon discountCoupon);
    }
}
