using System;
using System.Collections.Generic;
using System.Text;

namespace Rent.Models
{
    public class DiscountCouponRequest
    {
        public int Id { get; set; }
        public string Coupon { get; set; }
        public int MinDiscount { get; set; }
        public int MaxDiscount { get; set; }

        public DiscountCouponRequest()
        {

        }
    }
}
