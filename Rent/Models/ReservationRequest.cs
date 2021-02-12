using System;

namespace Rent.Models
{
    public class ReservationRequest
    {
        /// <summary>
        /// Special object for requesting from UI.
        /// </summary>
        public int? Id { get; set; }
        public int? CarId { get; set; }
        public int? CustomerId { get; set; }
        public int? DiscountCouponId { get; set; }
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
        public ReservationRequest()
        {

        }
        public ReservationRequest(int? id, int? carId, int? customerId, int? discountCouponId, DateTime? minDate, DateTime? maxDate)
        {
            Id = id;
            CarId = carId;
            CustomerId = customerId;
            DiscountCouponId = discountCouponId;
            MinDate = minDate;
            MaxDate = maxDate;
        }
    }
}
