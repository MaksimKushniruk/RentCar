using RentCar.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.Entities
{
    public class Reservation : BaseEntity
    {
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public Coupon Coupon { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public decimal Price { get; set; }
    }
}
