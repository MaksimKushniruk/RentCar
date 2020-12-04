using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface IDiscountCouponService
    {
        /// <summary>
        /// Creating DiscountCoupon. Returns DiscountCoupon object.
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        DiscountCoupon CreateDiscountCoupon(Dictionary<string, string> fields);
        /// <summary>
        ///  Deleting DiscountCoupon. Returns bool result of operation.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteDiscountCoupon(int id);
        /// <summary>
        /// Searching DiscountCoupon. Returns List<DiscountCoupon> with all found coupons.
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        List<DiscountCoupon> GetDiscountCoupon(Dictionary<string, string> fields);
        /// <summary>
        /// Updating DiscountCoupon. Returns updated object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fieldsForUpdate"></param>
        /// <returns></returns>
        DiscountCoupon UpdateDiscountCoupon(int id, Dictionary<string, string> fieldsForUpdate);
    }
}
