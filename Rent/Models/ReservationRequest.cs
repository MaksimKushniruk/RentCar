using System;

namespace Rent.Models
{
    public class ReservationRequest
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public int  DiscountCouponId { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public ReservationRequest()
        {

        }
    }
}
