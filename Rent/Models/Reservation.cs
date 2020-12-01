using System;

namespace Rent.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public DiscountCoupon DiscountCoupon { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public decimal? Price { get; set; }
        public Reservation(int id, Car car, Customer customer, DiscountCoupon discountCoupon, DateTime startDate, DateTime finalDate, decimal? price)
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
        public Reservation(Car car, Customer customer, DiscountCoupon discountCoupon, DateTime startDate, DateTime finalDate)
        {
            Id = Int32.MinValue;
            Car = car;
            Car.Status = CarRentStatus.InRent;
            Customer = customer;
            StartDate = startDate;
            FinalDate = finalDate;
            DiscountCoupon = discountCoupon;
            if (discountCoupon != null)
            {
                Price = (((car.PricePerHour * (decimal)Math.Round(finalDate.Subtract(startDate).TotalHours, MidpointRounding.ToPositiveInfinity))) / 100) * (100 - discountCoupon.Discount);
            }
            else
            {
                Price = car.PricePerHour * (decimal)Math.Round(finalDate.Subtract(startDate).TotalHours, MidpointRounding.ToPositiveInfinity);
            }
        }
    }
}
