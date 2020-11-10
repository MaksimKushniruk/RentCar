using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    interface IReservationService
    {
        string CreateReservation(Car car, Customer customer, DateTime startDate, DateTime finalDate, decimal price);
        string DeleteReservation(int id);
        Reservation GetReservation(int id);
        List<Reservation> GetReservation();
        string UpdateReservation(Reservation reservation);
    }
}
