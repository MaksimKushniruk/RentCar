
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Coupon : BaseEntity
    {
        public string CouponCode { get; set; }
        public int Discount { get; set; }
        public List<Reservation> Reservations { get; set; }
        public Coupon()
        {
            Reservations = new List<Reservation>();
        }
    }
}
