using System;
using System.Collections.Generic;
using System.Text;

namespace Rent.Models
{
    public class DiscountCouponRequest
    {
        /// <summary>
        /// Special object for requesting from UI.
        /// </summary>
        public int? Id { get; set; }
        public string Coupon { get; set; }
        public int? MinDiscount { get; set; }
        public int? MaxDiscount { get; set; }

        public DiscountCouponRequest()
        {

        }
        public DiscountCouponRequest(int? id, string coupon, int? minDiscount, int? maxDiscount)
        {
            Id = id;
            Coupon = coupon;
            MinDiscount = minDiscount;
            MaxDiscount = maxDiscount;
        }
    }
}
