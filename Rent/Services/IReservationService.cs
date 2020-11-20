using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface IReservationService
    {
        bool CreateReservation(out int reservationId, Car car, Customer customer, DiscountCoupon discountCoupon, DateTime startDate, DateTime finalDate, decimal price);
        bool DeleteReservation(int id);
        List<Reservation> GetReservation(ReservationRequest request);
        bool UpdateReservation(int id, Dictionary<string, string> fieldsForUpdate);
    }
}
