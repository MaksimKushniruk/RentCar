using System;
using Rent.Models;
using System.Data;
using System.Collections.Generic;

namespace Rent.Repositories
{
    interface IReservationRepository
    {
        bool AddReservation(Reservation reservation, out int id);
        bool DeleteReservation(int id);
        List<Reservation> GetReservation(ReservationRequest request);
        bool UpdateReservation(Reservation reservation);
    }
}
