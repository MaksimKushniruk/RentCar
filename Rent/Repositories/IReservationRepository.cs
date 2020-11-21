using System;
using Rent.Models;
using System.Data;
using System.Collections.Generic;

namespace Rent.Repositories
{
    interface IReservationRepository
    {
        int AddReservation(Reservation reservation);
        bool DeleteReservation(int id);
        List<Reservation> GetReservation(ReservationRequest request);
        bool UpdateReservation(Reservation reservation);
    }
}
