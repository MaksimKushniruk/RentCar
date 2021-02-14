using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public int Discount { get; set; }
    }
}