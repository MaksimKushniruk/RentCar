﻿using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface IReservationService
    {
        int CreateReservation(Car car, Customer customer, DiscountCoupon discountCoupon, DateTime startDate, DateTime finalDate, decimal price);
        int DeleteReservation(int id);
        List<Reservation> GetReservation(ReservationRequest request);
        int UpdateReservation(int id, Dictionary<string, string> fieldsForUpdate);
    }
}
