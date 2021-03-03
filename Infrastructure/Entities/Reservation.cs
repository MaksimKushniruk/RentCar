using System;

namespace Infrastructure.Entities
{
    public class Reservation : BaseEntity
    {
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int? CarId { get; set; }
        public Car Car { get; set; }

        public int? CouponId { get; set; }
        public Coupon Coupon { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public decimal? Price { get; set; }
    }
}
