using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CouponViewModel
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public int Discount { get; set; }
        public List<ReservationViewModel> Reservations { get; set; }
        public CouponViewModel()
        {
            Reservations = new List<ReservationViewModel>();
        }
    }
}
