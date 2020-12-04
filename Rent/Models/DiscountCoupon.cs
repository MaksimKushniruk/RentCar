using System;

namespace Rent.Models
{
    public class DiscountCoupon
    {
        /// <summary>
        /// The base object DiscountCoupon.
        /// </summary>
        public int? Id { get; set; }
        public string Coupon { get; set; }
        public int? Discount { get; set; }

        public DiscountCoupon(int id, string coupon, int discount)
        {
            Id = id;
            Coupon = coupon;
            Discount = discount;
        }
        public DiscountCoupon(string coupon, int discount)
        {
            Coupon = coupon;
            Discount = discount;
        }
    }
}
