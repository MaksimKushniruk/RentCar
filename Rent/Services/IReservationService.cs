using System;
using System.Collections.Generic;
using Rent.Models;

namespace Rent.Services
{
    public interface IReservationService
    {
        int CreateReservation(Reservation reservation);
        bool DeleteReservation(int id);
        List<Reservation> GetReservation(ReservationRequest request);
        bool UpdateReservation(int id, Dictionary<string, string> fieldsForUpdate);
    }
}
