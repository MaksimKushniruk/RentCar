using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface IReservationService
    {
        int CreateReservation(Car car, Customer customer, DiscountCoupon discountCoupon, DateTime startDate, DateTime finalDate, decimal price);
        int DeleteReservation(int id);
        Reservation GetReservation(int id);
        List<Reservation> GetReservation();
        int UpdateReservation(Reservation reservation);
    }
}
