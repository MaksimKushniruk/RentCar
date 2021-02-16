using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class ReservationDto : BaseEntityDto
    {
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }

        public int CarId { get; set; }
        public CarDto Car { get; set; }

        public int CouponId { get; set; }
        public CouponDto Coupon { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public decimal Price { get; set; }
    }
}
