using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public CustomerViewModel Customer { get; set; }
        public CarViewModel Car { get; set; }
        public CouponViewModel Coupon { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public decimal? Price { get; set; }
    }
}
