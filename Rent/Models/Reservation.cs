using System;

namespace Rent.Models
{
    public class Reservation
    {
        /// <summary>
        /// The base object Reservation.
        /// </summary>
        public int? Id { get; set; }
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public DiscountCoupon DiscountCoupon { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public decimal? Price { get; set; }
        public Reservation(Car car, Customer customer, DiscountCoupon discountCoupon, DateTime startDate)
        {
            Id = null;
            Car = car;
            Customer = customer;
            DiscountCoupon = discountCoupon;
            StartDate = startDate;
            FinalDate = null;
            Price = null;
        }
        public Reservation(int? id, Car car, Customer customer, DiscountCoupon discountCoupon, DateTime startDate)
        {
            Id = id;
            Car = car;
            Customer = customer;
            DiscountCoupon = discountCoupon;
            StartDate = startDate;
            FinalDate = null;
            Price = null;
        }
        public Reservation(int? id, Car car, Customer customer, DiscountCoupon discountCoupon, DateTime startDate, DateTime finalDate, decimal? price)
        {
            Id = id;
            Car = car;
            Car.Status = CarRentStatus.InRent;
            Customer = customer;
            StartDate = startDate;
            FinalDate = finalDate;
            DiscountCoupon = discountCoupon;
            Price = price;
        }
    }
}
