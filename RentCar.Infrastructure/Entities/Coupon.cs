using RentCar.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.Entities
{
    public class Coupon : BaseEntity
    {
        public string CouponCode { get; set; }
        public int Discount { get; set; }
    }
}